using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YJKBooks.Data;
using YJKBooks.Entities;

namespace YJKBooks.Controllers
{
    public class BooksController : BaseApiController
    {
        private readonly StoreContext _context;
        public BooksController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var books = await _context.Book.ToListAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            return await _context.Book.FindAsync(id);
        }
    }
}