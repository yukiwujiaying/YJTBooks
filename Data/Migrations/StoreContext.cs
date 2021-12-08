using Microsoft.EntityFrameworkCore;
using YJKBooks.Entities;

namespace YJKBooks.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book> Book { get; set; }
        public DbSet<User> Users { get; set; }
    }
}