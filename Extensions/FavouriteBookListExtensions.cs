using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YJKBooks.Entities;
using YJKBooks.Models;

namespace YJKBooks.Extensions
{
    public static class BasketExtensions
    {
         public static FavouriteBookListDto MapFavouriteBookListToDto(this FavouriteBookList favouriteBookList)
        {
            return new FavouriteBookListDto
            {
                Id = favouriteBookList.Id,
                UserId = favouriteBookList.UserId,
                Items = favouriteBookList.Items.Select(item => new BookListItemDto
                {
                    BookId = item.BookId,
                    Title = item.Book.Title,
                    Price = item.Book.Price,
                    PictureUrl = item.Book.PictureUrl,
                    Genre = item.Book.BookGenre,
                }).ToList()
            };
        }
    }
}

                                            