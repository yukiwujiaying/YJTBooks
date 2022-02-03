using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YJKBooks.Entities;

namespace YJKBooks.Models
{
    public class ReviewDto
    {
        public string BookTitle { get; set; }
        public int Id { get; set; }
        public int BookId { get; set; }
        public string UserId {get; set;}
        public DateTime PublishedDate;
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string UserName { get; set; }

        public string PictureUrl {get; set;}
       
    }
}
