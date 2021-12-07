using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YJKBooks.Entities
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PictureUrl { get; set; }
        public string Synopsis { get; set; }
        public string AmazonLink { get; set; }
      /*  [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } */
        public ICollection<Review> BookReviews { get; set; }
        public double Price { get; set; }
        public Genre BookGenre { get; set; }
    }
}
