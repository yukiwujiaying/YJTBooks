using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YJKBooks.RequestHelper
{
    public class BookPrams : PaginationParams
    {
         public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public string Genre{get; set;}
    }
}