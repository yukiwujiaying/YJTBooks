using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YJKBooks.Models
{
    public class ReviewDto
    {
        public int Id { get; set; }
      
        public string Description { get; set; }

        public int Rating { get; set; }
    }
}
