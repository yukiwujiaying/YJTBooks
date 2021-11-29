using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YJKBooks.Entities;

namespace YJKBooks.Contexts
{
    public class UsersInfoDbContext : DbContext
    {
        //Dbset can be used to query and save instances of its entity type
        //link queries against the Dbset will be translated into queries against the database
        public DbSet<Users> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        //this is the constructor that allow the config to use the onnection string
        public UsersInfoDbContext(DbContextOptions<UsersInfoDbContext> options) : base(options)
        {

        }
    }
}
