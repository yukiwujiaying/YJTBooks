using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YJKBooks.Contexts;
using YJKBooks.Entities;

namespace YJKBooks.Controllers
{  
    // [ApiController]
    // [Route("api/[controller]")]
    public class BooksController : BaseApiController
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book==null) return NotFound();
            return book;
        }
    }
    }
