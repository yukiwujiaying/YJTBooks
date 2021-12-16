using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace YJKBooks.Entities
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }
        public ICollection<Book> FavouriteBooks { get; set; }
        public ICollection<Review> UserReviews { get; set; }
    }
}