using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YJKBooks.Entities;

namespace YJKBooks.Models
{
    //What is return from or accepted by our API is not the same entities used by the underlying data store
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Link { get; set; }
        public string Synopsis { get; set; }

        public long Price { get; set; }

        public string PictureUrl { get; set; }

        public ICollection<ReviewDto> BookReviews { get; set; }

    }
}
