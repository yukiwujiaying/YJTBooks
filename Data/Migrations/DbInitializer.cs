using System.Collections.Generic;
using System.Linq;
using YJKBooks.Data;
using YJKBooks.Entities;

namespace YJKBooks.Migrations
{
    public static class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            if (context.Book.Any()) return;

            var books = new List<Book>
            {
                new Book
                {
                    Title = "Anna Karenina",
                    Author = "Leo Tolstoy",
                    PictureUrl = "/images/books/annakarenina.png",
                    Synopsis = "Anna Karenina tells of the doomed love affair between the sensuous and rebellious Anna and the dashing officer, Count Vronsky. Tragedy unfolds as Anna rejects her passionless marriage and must endure the hypocrisies of society. Set against a vast and richly textured canvas of nineteenth-century Russia, the novel's seven major characters create a dynamic imbalance, playing out the contrasts of city and country life and all the variations on love and family happiness. While previous versions have softened the robust, and sometimes shocking, quality of Tolstoy's writing, Pevear and Volokhonsky have produced a translation true to his powerful voice. This award-winning team's authoritative edition also includes an illuminating introduction and explanatory notes. Beautiful, vigorous, and eminently readable, this Anna Karenina will be the definitive text for generations to come.",
                    Genre = "Drama",
                },
                new Book
		        {
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    PictureUrl = "/images/books/prideandprejudice.png",
                    Synopsis = "Sparks fly when spirited Elizabeth Bennet meets single, rich, and proud Mr. Darcy. But Mr. Darcy reluctantly finds himself falling in love with a woman beneath his class. Can each overcome their own pride and prejudice?",
                    Genre = "Romance",
                },
                new Book
                {
                    Title = "1984",
                    Author = "George Orwell",
                    PictureUrl = "/images/books/1984.png",
                    Synopsis = "Winston Smith attempts to fights back against a totalitarian Party that rules Oceania and his entire life. It is a dystopian novel that tells the story of Winston Smith and warns of the dangers of a totalitarian government that rules through fear, surveillance, propaganda, and brainwashing.",
                    Genre = "Sci-Fi",
                },
                new Book
		        {
                    Title = "Hamlet",
                    Author = "William Shakespeare",
                    PictureUrl = "/images/books/hamlet.png",
                    Synopsis = "Prince Hamlet is depressed. Having been summoned home to Denmark from school in Germany to attend his father's funeral, he is shocked to find his mother Gertrude already remarried. The Queen has wed Hamlet's Uncle Claudius, the dead king's brother.",
                    Genre = "Tragedy",
                },
                new Book
                {
                    Title = "The Stranger",
                    Author = "Albert Camus",
                    PictureUrl = "/images/books/thestranger.png",
                    Synopsis = "The Stranger tells the strange and baffling story of a young shipping clerk, Meursault, and the surprising ways he reacts to the world around him.",
                    Genre = "Philosophical",
                },
                new Book
		        {
                    Title = "The Trial",
                    Author = "Franz Kafka",
                    PictureUrl = "/images/books/thetrial.png",
                    Synopsis = "The Trial is the chronicle of that intervening year of K.'s case, his struggles and encounters with the invisible Law and the untouchable Court. It is an account, ultimately, of state-induced self-destruction. Yet, as in all of Kafka's best writing, the 'meaning' is far from clear.",
                    Genre = "Fiction",
                },
                new Book
                {
                    Title = "Invisible Man",
                    Author = "Ralph Ellison",
                    PictureUrl = "/images/books/invisibleman.png",
                    Synopsis = "Invisible Man is the story of a young black man from the South who does not fully understand racism in the world. Filled with hope about his future, he goes to college, but gets expelled for showing one of the white benefactors the real and seamy side of black existence.",
                    Genre = "Fiction",
                },
                new Book
		        {
                    Title = "Midnights Children",
                    Author = "Salman Rushdie",
                    PictureUrl = "/images/books/midnightschildren.png",
                    Synopsis = "Midnight children covers the experiences of three generations of a Sinai family living in Srinagar Amritsar and Agra and then in Bombay and finally migrating to Karachi. Saleem Sinai is the narrator of the events. He works in a pickle factory by day and records his experiences by night.",
                    Genre = "Magic Realism",
                },
                new Book
                {
                    Title = "Dead Souls",
                    Author = "Nikolai Gogol",
                    PictureUrl = "/images/books/deadsouls.png",
                    Synopsis = "Dead Souls Summary Dead Souls, by Nikolai Gogol, is a satirical examination of 1800's Russian nobility and society. The work is often called Gogol's greatest. It is also considered a Russian prose poem. In post-Napoleonic Russia, landowners owned serfs who worked the land.",
                    Genre = "Fiction",
                },
                new Book
		        {
                    Title = "Ulysses",
                    Author = "James Joyce",
                    PictureUrl = "/images/books/ulysses.png",
                    Synopsis = "Ulysses follows Leopold Bloom as he goes from place to place in Dublin over the course of June 16, 1904, from 8 a.m. until 3 a.m. Joyce chose that particular day because it wasthe day of his first date with his wife, Nora Barnacle.",
                    Genre = "Modernist",
                },
            };

            foreach (var book in books)
            {
                context.Book.Add(book);
            }

            context.SaveChanges();
        }
    }
}