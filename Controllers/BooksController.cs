using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YJKBooks.Contexts;
using YJKBooks.Entities;
using YJKBooks.Models;

namespace YJKBooks.Controllers
{
    public class BooksController : BaseApiController
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            var userFavouriteBooks = await _context.FavouriteBookList.Include(i => i.Items)
                                                                     .ThenInclude(b => b.Book)
                                                                     .FirstOrDefaultAsync(x => x.UserId == Request.Cookies["userId"]);

            var bookDto = (from book in books
                           join favourite in userFavouriteBooks.Items
                           on book.Id equals favourite.BookId
                           into dto
                           from subBook in dto.DefaultIfEmpty()
                           select new BookDto
                           {
                               Id = book.Id,
                               Title = book.Title,
                               Author = book.Author,
                               Link = book.Link,
                               Synopsis = book.Synopsis,
                               Price = book.Price,
                               PictureUrl = book.PictureUrl,
                               IsFavourite = subBook is null ? false : true,
                               Genre = book.BookGenre
                           }).ToList();
            return bookDto;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();
            return book;
        }


        private BookDto MapBookToDto(Book Book)
        {
            return new BookDto
            {
                Id = Book.Id,
                Title = Book.Title,
                Author = Book.Author,
                Link = Book.Link,
                Synopsis = Book.Synopsis,
                Price = Book.Price,
                PictureUrl = Book.PictureUrl,
                IsFavourite = false,
                Genre = Book.BookGenre
            };
        }
    }
}
