using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YJKBooks.Entities
{
    public class BookListItem
    {
       public int id { get; set; }
        public int Quantity { get; set; }

        //navigation properties
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int FavouriteBookListId {get; set;}
        public FavouriteBookList FavouriteBookList{get; set;} 
    }
}