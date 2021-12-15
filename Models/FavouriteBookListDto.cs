using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YJKBooks.Models
{
    public class FavouriteBookListDto
    {
        public int Id {get; set;}
        public string UserId{get; set;}
        public List<BookListItemDto> Items {get; set;}
    }
}