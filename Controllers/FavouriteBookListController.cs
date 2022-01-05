using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YJKBooks.Contexts;
using YJKBooks.Entities;
using YJKBooks.Models;

namespace YJKBooks.Controllers
{
    public class FavouriteBookListController : BaseApiController
    {
        private readonly ApplicationDbContext _context;

        public FavouriteBookListController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name ="GetFavouriteBookList")]
        public async Task<ActionResult<FavouriteBookListDto>> GetFavouriteBookList()
        {
            var favouriteBookList = await RetrieveFavouriteBookList();

            if (favouriteBookList == null) return NotFound();

            return MapFavouriteBookListToDto(favouriteBookList);
        }

        [HttpPost]// api/basket?bookId=3&quantity=2
        public async Task<ActionResult<FavouriteBookListDto>> AddItemToBasket(int bookId, int quantity)
        {
            //get FavouriteBookList
            var favouriteBookList = await RetrieveFavouriteBookList();

            //checked if FavouriteBookList is null or not. If null create FavouriteBookList
            if (favouriteBookList == null) favouriteBookList = CreateFavouriteBookList();

            //get book
            var book = await _context.Books.FindAsync(bookId);
            if (book == null) return NotFound();

            //add Item
            favouriteBookList.AddItem(book, quantity);

            //save changes
            var result = await _context.SaveChangesAsync() > 0;
            if (result) return CreatedAtRoute("GetFavouriteBookList",MapFavouriteBookListToDto(favouriteBookList) );

            return BadRequest(new ProblemDetails { Title = "Problem saving book to your FavouritecBook List" });
        }



        [HttpDelete]
        public async Task<ActionResult> RemoveFavouriteBookListItem(int bookId, int quantity)
        {
            //get FavouriteBookList
            var favouriteBookList = await RetrieveFavouriteBookList();
            //checked if basket is null, if null return not found
            if (favouriteBookList == null) return NotFound();
            //remove item or reduce quantity
            favouriteBookList.RemoveItem(bookId, quantity);
            //save changes
            var result = await _context.SaveChangesAsync() > 0;
            if (result) return Ok();

            return BadRequest(new ProblemDetails { Title = "Problem removing item from the basket" });
        }

        private async Task<FavouriteBookList> RetrieveFavouriteBookList()
        {
            return await _context.FavouriteBookList
                .Include(i => i.Items)
                .ThenInclude(b => b.Book)
                .FirstOrDefaultAsync(x => x.UserId == Request.Cookies["userId"]);
        }

        private FavouriteBookList CreateFavouriteBookList()
        {
            var userId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(30) };
            Response.Cookies.Append("userId", userId, cookieOptions);
            var favouriteBookList = new FavouriteBookList { UserId = userId };
            _context.FavouriteBookList.Add(favouriteBookList);
            return favouriteBookList;
        }

        private FavouriteBookListDto MapFavouriteBookListToDto(FavouriteBookList FavouriteBookList)
        {
            return new FavouriteBookListDto
            {
                Id = FavouriteBookList.Id,
                UserId = FavouriteBookList.UserId,
                Items = FavouriteBookList.Items.Select(item => new BookListItemDto
                {
                    BookId = item.BookId,
                    Title = item.Book.Title,
                    Price = item.Book.Price,
                    PictureUrl = item.Book.PictureUrl,
                    Author = item.Book.Author,
                    Link = item.Book.Link,
                    Quantity = item.Quantity,
                    Genre =  item.Book.BookGenre
                }).ToList()
            };
        }

    }
}