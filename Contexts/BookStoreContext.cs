using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YJKBooks.Entities;

namespace YJKBooks.Contexts
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>()
                 .HasData(
                new Book()
                {
                    BookId = 1,
                    Title = "The Hobbit",
                    Author = "J. R. R. Tolkien",
                    PictureUrl = "http://4.bp.blogspot.com/-Q2jfDj24R9Q/UMX-5B1zJ2I/AAAAAAAAAHw/0rOGgxaYtnw/s1600/The+Hobbit.jpg",
                    Synopsis = "Bilbo Baggins enjoys a quiet and contented life, with no desire to travel far from the comforts of home; then one day the wizard Gandalf and a band of dwarves arrive unexpectedly and enlist his services – as a burglar – on a dangerous expedition to raid the treasure-hoard of Smaug the dragon. Bilbo’s life is never to be the same again.",
                    AmazonLink = "https://www.amazon.co.uk/Hobbit-J-R-Tolkien/dp/0007458428/ref=asc_df_0007458428?tag=bingshoppinga-21&linkCode=df0&hvadid=80882880812450&hvnetw=o&hvqmt=e&hvbmt=be&hvdev=c&hvlocint=&hvlocphy=&hvtargid=pla-4584482456235141&psc=1"
                },
                new Book()
                {
                    BookId = 2,
                    Title = "The Lord of the Rings ",
                    Author = "J. R. R. Tolkien",
                    PictureUrl = "http://d20eq91zdmkqd.cloudfront.net/assets/images/book/large/9780/0075/9780007581146.jpg",
                    Synopsis = "Sauron, the Dark Lord, has gathered to him all the Rings of Power – the means by which he intends to rule Middle-earth. All he lacks in his plans for dominion is the One Ring – the ring that rules them all – which has fallen into the hands of the hobbit, Bilbo Baggins. In a sleepy village in the Shire, young Frodo Baggins finds himself faced with an immense task, as the Ring is entrusted to his care. He must leave his home and make a perilous journey across the realms of Middle-earth to the Crack of Doom, deep inside the territories of the Dark Lord. There he must destroy the Ring forever and foil the Dark Lord in his evil purpose.",
                    AmazonLink = "https://www.amazon.co.uk/Lord-Rings-Boxed-Set/dp/0007581149/ref=asc_df_0007581149?tag=bingshoppinga-21&linkCode=df0&hvadid=80608002971184&hvnetw=o&hvqmt=e&hvbmt=be&hvdev=c&hvlocint=&hvlocphy=&hvtargid=pla-4584207578206752&psc=1"
                },
                 new Book
                 {
                     BookId = 3,
                     Title = "The Hunger Games",
                     Author = "Suzanne Collins",
                     PictureUrl = "/Data/BookImages/The-Hunger-Games.jpg",
                     Synopsis = "In the ruins of a place once known as North America lies the nation of Panem, a shining Capitol surrounded by twelve outlying districts. The Capitol is harsh and cruel and keeps the districts in line by forcing them all to send one boy and one girl between the ages of twelve and eighteen to participate in the annual Hunger Games, a fight to the death on live TV.Sixteen-year-old Katniss Everdeen, who lives alone with her mother and younger sister, regards it as a death sentence when she steps forward to take her sister's place in the Games. But Katniss has been close to dead before—and survival, for her, is second nature. Without really meaning to, she becomes a contender. But if she is to win, she will have to start making choices that weight survival against humanity and life against love.",
                     AmazonLink = "https://www.amazon.co.uk/Hunger-Games-Trilogy-Suzanne-Collins/dp/1407135449/ref=sr_1_11?keywords=hunger+games+book+1&qid=1638371618&sr=8-11"

                 },
                new Book
                {
                    BookId = 4,
                    Title = "East of Eden",
                    Author = "John Steinbeck",
                    PictureUrl = "https://bookaudio.online/uploads/images/media/184/jT_yinMH8Xl8UiU3-john-steinbeck-east-of-eden.jpg",
                    Synopsis = "In the ruins of a place once known as North America lies the nation of Panem, a shining Capitol surrounded by twelve outlying districts. The Capitol is harsh and cruel and keeps the districts in line by forcing them all to send one boy and one girl between the ages of twelve and eighteen to participate in the annual Hunger Games, a fight to the death on live TV.Sixteen-year-old Katniss Everdeen, who lives alone with her mother and younger sister, regards it as a death sentence when she steps forward to take her sister's place in the Games. But Katniss has been close to dead before—and survival, for her, is second nature. Without really meaning to, she becomes a contender. But if she is to win, she will have to start making choices that weight survival against humanity and life against love.",
                    AmazonLink = "https://www.amazon.co.uk/East-Eden-John-Steinbeck/dp/0670287385"
                },
                new Book()
                {
                    BookId = 5,
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    PictureUrl = "https://almabooks.com/wp-content/uploads/2016/10/9781847493699.jpg",
                    Synopsis = "The pride of high-ranking Mr Darcy and the prejudice of middle-class Elizabeth Bennet conduct an absorbing dance through the rigid social hierarchies of early-nineteenth-century England, with the passion of the two unlikely lovers growing as their union seems ever more improbable.",
                    AmazonLink = "https://www.amazon.co.uk/Pride-Prejudice-Alma-Classics-Evergreens/dp/1847493696/ref=asc_df_1847493696?tag=bingshoppinga-21&linkCode=df0&hvadid=80401845130311&hvnetw=o&hvqmt=e&hvbmt=be&hvdev=c&hvlocint=&hvlocphy=&hvtargid=pla-4584001419445871&psc=1"
                }
                ); ;


            base.OnModelCreating(modelBuilder);

        }
    }
}

