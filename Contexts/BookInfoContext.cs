using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YJKBooks.Entities;

namespace YJKBooks.Contexts
{
    public class BookInfoContext :DbContext
    {
        public DbSet<Book> Books { get; set; }

        //this is the constructor that allow the config to use the onnection string
        public BookInfoContext(DbContextOptions<BookInfoContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                 .HasData(
                new Book()
                {
                    Id = 1,
                    Name = "The Hobbit",
                    Author = "J. R. R. Tolkien",
                    Description = "Bilbo Baggins enjoys a quiet and contented life, with no desire to travel far from the comforts of home; then one day the wizard Gandalf and a band of dwarves arrive unexpectedly and enlist his services – as a burglar – on a dangerous expedition to raid the treasure-hoard of Smaug the dragon. Bilbo’s life is never to be the same again.",
                    Link = "https://www.amazon.co.uk/Hobbit-J-R-Tolkien/dp/0007458428/ref=asc_df_0007458428?tag=bingshoppinga-21&linkCode=df0&hvadid=80882880812450&hvnetw=o&hvqmt=e&hvbmt=be&hvdev=c&hvlocint=&hvlocphy=&hvtargid=pla-4584482456235141&psc=1"
                },
                new Book()
                {
                    Id = 2,
                    Name = "The Lord of the Rings ",
                    Author = "J. R. R. Tolkien",
                    Description = "Sauron, the Dark Lord, has gathered to him all the Rings of Power – the means by which he intends to rule Middle-earth. All he lacks in his plans for dominion is the One Ring – the ring that rules them all – which has fallen into the hands of the hobbit, Bilbo Baggins. In a sleepy village in the Shire, young Frodo Baggins finds himself faced with an immense task, as the Ring is entrusted to his care. He must leave his home and make a perilous journey across the realms of Middle-earth to the Crack of Doom, deep inside the territories of the Dark Lord. There he must destroy the Ring forever and foil the Dark Lord in his evil purpose.",
                    Link = "https://www.amazon.co.uk/Lord-Rings-Boxed-Set/dp/0007581149/ref=asc_df_0007581149?tag=bingshoppinga-21&linkCode=df0&hvadid=80608002971184&hvnetw=o&hvqmt=e&hvbmt=be&hvdev=c&hvlocint=&hvlocphy=&hvtargid=pla-4584207578206752&psc=1"
                },
                new Book()
                {
                    Id = 3,
                    Name = "Pride and Prejudice",
                    Author = "Jane Austen",
                    Description = "The pride of high-ranking Mr Darcy and the prejudice of middle-class Elizabeth Bennet conduct an absorbing dance through the rigid social hierarchies of early-nineteenth-century England, with the passion of the two unlikely lovers growing as their union seems ever more improbable.",
                    Link = "https://www.amazon.co.uk/Pride-Prejudice-Alma-Classics-Evergreens/dp/1847493696/ref=asc_df_1847493696?tag=bingshoppinga-21&linkCode=df0&hvadid=80401845130311&hvnetw=o&hvqmt=e&hvbmt=be&hvdev=c&hvlocint=&hvlocphy=&hvtargid=pla-4584001419445871&psc=1"
                }
                ); ;
            base.OnModelCreating(modelBuilder);

        }
    }
}
