using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YJKBooks.Models
{
    public class UsersDto
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public FavouriteBookListDto FavouriteBooks { get; set; }
        public ReviewDto BookReviews { get; set; }

    }
}

