using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YJKBooks.Models
{
    //What is return from or accepted by our API is not the same entities used by the underlying data store
    public class BookDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Link { get; set; }
        public string Description { get; set; }

    }
}
