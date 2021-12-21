using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YJKBooks.Contexts;
using YJKBooks.Entities;

namespace YJKBooks.Controllers {

    public class BooksController : BaseApiController
    {

        private readonly BookStoreContext context;

        public BooksController(BookStoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return await context.Books.ToListAsync();
           
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null) 
                return NotFound();

            return book;
        }

    }
}
