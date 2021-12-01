using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YJKBooks.Contexts;
using YJKBooks.Entities;

namespace YJKBooks.Controllers {

    [ApiController]
    [Route("api/[controller]")]


    public class BooksController : ControllerBase
    {

        private readonly BookStoreContext context;

        public BooksController(BookStoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            var books = context.Books.ToList();
            return Ok(books);
        }
        [HttpGet("{id}")]

        public ActionResult<Book> GetBook(int id)
        {
            return context.Books.Find(id);
        }

    }
}
