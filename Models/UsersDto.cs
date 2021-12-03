﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YJKBooks.Models
{
    public class UsersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public IList<BookDto> FavouriteBooks { get; set; }
        public IList<ReviewDto> BookReviews { get; set; }

    }
}
