using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YJKBooks.RequestHelper
{
    public class PaginationParams
    {
        private const int MaxPageSize = 50;
        // 1 is the default page number always get 1 page
        public int PageNumber{get; set;}=1;
        private int _pageSize = 5;
        public int PageSize
        {
            get => _pageSize;
            // if value > max page size return max page size, else return value
            set => _pageSize = value > MaxPageSize? MaxPageSize : value;
        }
    }
}