using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace YJKBooks.RequestHelper
{
    public class PageList<T> : List<T>
    {
        //constructor
        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPage = (int)Math.Ceiling(count / (double)pageSize)
            };
            AddRange(items);
            // the PageList will return the metadata and the items inside it as well
        }

        public MetaData MetaData { get; set; }

        public static async Task<PageList<T>> ToPagedlist(IQueryable<T> query, int pageNumber, int pageSize)
        {
            //CountSdync() : Asynchronously returns the number of elements in a query.
            var count = await query.CountAsync();

            //if one page 1, pagesize is 10(show 10 items on page) skip 0
            //if on page 2, we will skip the first 10 items
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}