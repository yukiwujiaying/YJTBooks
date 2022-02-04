using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using YJKBooks.Entities;
using YJKBooks.Models;
using static YJKBooks.Entities.Book;

namespace  YJKBooks.Extensions
{
    public static class ProductExtensions
    {
        public static IQueryable<Book> Sort(this IQueryable<Book> query, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(p=>p.Title);
            query = orderBy switch
            {
                "price" => query.OrderBy(p=>p.Price),
                "priceDesc" => query.OrderByDescending(p=>p.Price),
                //_is default case
                _=>query.OrderBy(p=>p.Title)
            };
            return query;
        }

        public static IQueryable<Book> Search(this IQueryable<Book> query, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) return query;
            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();
            return query.Where(p=>p.Title.ToLower().Contains(lowerCaseSearchTerm));
        }

        public static IQueryable<Book> Filter(this IQueryable<Book> query, string genre)
        {
            if (string.IsNullOrEmpty(genre))
            {
                return query;
            }
                              
            var genreList = genre.Split(",")
                                 .Select(x => Enum.Parse(typeof(Genre), x))
                                 .ToList();

            return query.Where(p=> genreList.Contains(p.BookGenre));            
        }
    }
}