using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YJKBooks.Contexts;
using YJKBooks.Entities;

namespace YJKBooks.Data
{
    public class DBInitializer
    {

        public static void Initialize(BookStoreContext context)
        {
            if (context.Books.Any()) return; // in case there are no Books in the Dataset

            var books = new List<Book>
            {
                new Book
                {
                    BookId = 1,
                    Title = "The Hunger Games",
                    Author = "Suzanne Collins",
                    PictureUrl = "/Data/BookImages/The-Hunger-Games.jpg",
                    Synopsis = "In the ruins of a place once known as North America lies the nation of Panem, a shining Capitol surrounded by twelve outlying districts. The Capitol is harsh and cruel and keeps the districts in line by forcing them all to send one boy and one girl between the ages of twelve and eighteen to participate in the annual Hunger Games, a fight to the death on live TV.Sixteen-year-old Katniss Everdeen, who lives alone with her mother and younger sister, regards it as a death sentence when she steps forward to take her sister's place in the Games. But Katniss has been close to dead before—and survival, for her, is second nature. Without really meaning to, she becomes a contender. But if she is to win, she will have to start making choices that weight survival against humanity and life against love.",
                    AmazonLink = "https://www.amazon.co.uk/Hunger-Games-Trilogy-Suzanne-Collins/dp/1407135449/ref=sr_1_11?keywords=hunger+games+book+1&qid=1638371618&sr=8-11"

                },
                new Book
                {
                    BookId = 2,
                    Title = "East of Eden",
                    Author = "John Steinbeck",
                    PictureUrl = "https://bookaudio.online/uploads/images/media/184/jT_yinMH8Xl8UiU3-john-steinbeck-east-of-eden.jpg",
                    Synopsis = "In the ruins of a place once known as North America lies the nation of Panem, a shining Capitol surrounded by twelve outlying districts. The Capitol is harsh and cruel and keeps the districts in line by forcing them all to send one boy and one girl between the ages of twelve and eighteen to participate in the annual Hunger Games, a fight to the death on live TV.Sixteen-year-old Katniss Everdeen, who lives alone with her mother and younger sister, regards it as a death sentence when she steps forward to take her sister's place in the Games. But Katniss has been close to dead before—and survival, for her, is second nature. Without really meaning to, she becomes a contender. But if she is to win, she will have to start making choices that weight survival against humanity and life against love.",
                    AmazonLink = "https://www.amazon.co.uk/East-Eden-John-Steinbeck/dp/0670287385"
                }
            }; 

            foreach( var book in books)
            {
                context.Books.Add(book);
            }

            context.SaveChanges();
        }
    }
}
