using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YJKBooks.Entities
{
    public class Book
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PictureUrl { get; set; }
        public string Synopsis { get; set; }
        public string AmazonLink { get; set; }
        public ICollection<Review> BookReviews { get; set; }
    }
}
