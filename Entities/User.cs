using System.Collections.Generic;

namespace YJKBooks.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public ICollection<Book> FavouriteBooks { get; set; }
        public ICollection<Review> UserReviews { get; set; }
    }
}