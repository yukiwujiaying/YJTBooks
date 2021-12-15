using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YJKBooks.Entities
{
    public class FavouriteBookList
    {
       public int Id{get; set;}
        public string UserId{get; set;}
        public List<BookListItem> Items {get; set;} = new(); 
        public void AddItem(Book book, int quantity)
        {  
            if(Items.All(item => item.BookId != book.Id))
            {
                //if the item is not in favouritebooklist before, add it in booklistitem
                //a basketitem can only have one item
                Items.Add(new BookListItem{Book = book, Quantity=quantity});
            }
            var existingItem = Items.FirstOrDefault(item=>item.BookId==book.Id);
            if (existingItem!=null) existingItem.Quantity = existingItem.Quantity+quantity;
        }

        public void RemoveItem(int bookId, int quantity)
        {
            var item =Items.FirstOrDefault(item=>item.BookId==bookId);
            if (item == null) return;
            item.Quantity -= quantity;
            if (item.Quantity==0) Items.Remove(item);
        }
    }
}