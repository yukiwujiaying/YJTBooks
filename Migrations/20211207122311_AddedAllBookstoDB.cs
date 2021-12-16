﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace YJKBooks.Migrations
{
    public partial class AddedAllBookstoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookGenre",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "Price",
                table: "Books",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                columns: new[] { "BookGenre", "Price" },
                values: new object[] { 1, 6L });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                columns: new[] { "BookGenre", "Price" },
                values: new object[] { 1, 39L });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                columns: new[] { "AmazonLink", "Author", "BookGenre", "PictureUrl", "Price", "Synopsis", "Title" },
                values: new object[] { "https://www.amazon.co.uk/Pride-Prejudice-Alma-Classics-Evergreens/dp/1847493696/ref=asc_df_1847493696?tag=bingshoppinga-21&linkCode=df0&hvadid=80401845130311&hvnetw=o&hvqmt=e&hvbmt=be&hvdev=c&hvlocint=&hvlocphy=&hvtargid=pla-4584001419445871&psc=1", "Jane Austen", 3, "/images/books/prideandprejudice.png", 5L, "The pride of high-ranking Mr Darcy and the prejudice of middle-class Elizabeth Bennet conduct an absorbing dance through the rigid social hierarchies of early-nineteenth-century England, with the passion of the two unlikely lovers growing as their union seems ever more improbable.", "Pride and Prejudice" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4,
                columns: new[] { "AmazonLink", "Author", "BookGenre", "PictureUrl", "Price", "Synopsis", "Title" },
                values: new object[] { "https://www.amazon.co.uk/Anna-Karenina-Wordsworth-Classics-Tolstoy/dp/1853262714", "Leo Tolsoy", 4, "/images/books/AnnaKarenina.png", 12L, "Anna Karenina tells of the doomed love affair between the sensuous and rebellious Anna and the dashing officer, Count Vronsky. Tragedy unfolds as Anna rejects her passionless marriage and must endure the hypocrisies of society. Set against a vast and richly textured canvas of nineteenth-century Russia, the novel's seven major characters create a dynamic imbalance, playing out the contrasts of city and country life and all the variations on love and family happiness. While previous versions have softened the robust, and sometimes shocking, quality of Tolstoy's writing, Pevear and Volokhonsky have produced a translation true to his powerful voice. This award-winning team's authoritative edition also includes an illuminating introduction and explanatory notes. Beautiful, vigorous, and eminently readable, this Anna Karenina will be the definitive text for generations to come.", "Anna Karenina" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5,
                columns: new[] { "AmazonLink", "Author", "BookGenre", "PictureUrl", "Price", "Synopsis", "Title" },
                values: new object[] { "https://www.amazon.co.uk/1984-Nineteen-Eighty-Four-Twentieth-Masterpiece/dp/184697576X/ref=sr_1_1_sspa?crid=3SC3VA96NF93Z&keywords=1984+george+orwell&qid=1638528594&s=books&sprefix=1984%2Cstripbooks%2C164&sr=1-1-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUEzTkRPWkQ4MDNLMlpQJmVuY3J5cHRlZElkPUEwODI1NzI1MVkzWUFEWUhTMVM1TCZlbmNyeXB0ZWRBZElkPUEwNjk5MzU2RFNJSTdLSjlKVUU0JndpZGdldE5hbWU9c3BfYXRmJmFjdGlvbj1jbGlja1JlZGlyZWN0JmRvTm90TG9nQ2xpY2s9dHJ1ZQ==", "George Orwell", 5, "/images/books/1984.png", 5L, "Winston Smith attempts to fights back against a totalitarian Party that rules Oceania and his entire life. It is a dystopian novel that tells the story of Winston Smith and warns of the dangers of a totalitarian government that rules through fear, surveillance, propaganda, and brainwashing.", "1984" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AmazonLink", "Author", "BookGenre", "PictureUrl", "Price", "Synopsis", "Title", "UserId" },
                values: new object[,]
                {
                    { 20, "https://www.amazon.co.uk/East-Eden-John-Steinbeck/dp/0670287385", "John Steinbeck", 0, "https://bookaudio.online/uploads/images/media/184/jT_yinMH8Xl8UiU3-john-steinbeck-east-of-eden.jpg", 61L, "In the ruins of a place once known as North America lies the nation of Panem, a shining Capitol surrounded by twelve outlying districts. The Capitol is harsh and cruel and keeps the districts in line by forcing them all to send one boy and one girl between the ages of twelve and eighteen to participate in the annual Hunger Games, a fight to the death on live TV.Sixteen-year-old Katniss Everdeen, who lives alone with her mother and younger sister, regards it as a death sentence when she steps forward to take her sister's place in the Games. But Katniss has been close to dead before—and survival, for her, is second nature. Without really meaning to, she becomes a contender. But if she is to win, she will have to start making choices that weight survival against humanity and life against love.", "East of Eden", null },
                    { 19, "https://www.amazon.co.uk/Hunger-Games-Trilogy-Suzanne-Collins/dp/1407135449/ref=sr_1_11?keywords=hunger+games+book+1&qid=1638371618&sr=8-11", "Suzanne Collins", 0, "/images/books/The-Hunger-Games.jpg", 17L, "In the ruins of a place once known as North America lies the nation of Panem, a shining Capitol surrounded by twelve outlying districts. The Capitol is harsh and cruel and keeps the districts in line by forcing them all to send one boy and one girl between the ages of twelve and eighteen to participate in the annual Hunger Games, a fight to the death on live TV.Sixteen-year-old Katniss Everdeen, who lives alone with her mother and younger sister, regards it as a death sentence when she steps forward to take her sister's place in the Games. But Katniss has been close to dead before—and survival, for her, is second nature. Without really meaning to, she becomes a contender. But if she is to win, she will have to start making choices that weight survival against humanity and life against love.", "The Hunger Games", null },
                    { 18, "https://www.amazon.co.uk/s?k=the+man+who+died+twice+richard+osman&i=stripbooks&crid=3Q844228FAPDJ&sprefix=The+men+who+di%2Cstripbooks%2C176&ref=nb_sb_ss_sc_1_14", "Richard Osman", 0, "/images/books/Themanwhodiestwice.jpg", 9L, "Elizabeth has received a letter from an old colleague, a man with whom she has a long history. He's made a big mistake, and he needs her help. His story involves stolen diamonds, a violent mobster, and a very real threat to his life.As bodies start piling up, Elizabeth enlists Joyce, Ibrahim and Ron in the hunt for a ruthless murderer. And if they find the diamonds too? Well, wouldn't that be a bonus?But this time they are up against an enemy who wouldn't bat an eyelid at knocking off four septuagenarians. Can the Thursday Murder Club find the killer (and the diamonds) before the killer finds them?", "The Man Who Died Twice ", null },
                    { 17, "https://www.amazon.co.uk/Republic-Penguin-Classics-Plato/dp/0140455116/ref=sr_1_3?crid=2WSL8U42WFLDJ&keywords=plato+republic&qid=1638547554&s=books&sprefix=plato+%2Cstripbooks%2C502&sr=1-3", "Plato", 7, "/images/books/The_Republic.jpg", 7L, "Plato's Republic is widely acknowledged as one of the most influential works in the history of philosophy. Presented in the form of a dialogue between Socrates and three different interlocutors, it is an inquiry into the notion of a perfect community and the ideal individual within it. During the conversation other questions are raised: what is goodness; what is reality; what is knowledge; what is the purpose of education? With remarkable lucidity and deft use of allegory, Plato arrives at a depiction of a state bound by harmony and ruled by 'philosopher kings'.", "The Republic", null },
                    { 16, "https://www.amazon.co.uk/Fire-Blood-Thrones-Targaryen-History/dp/0008402787/ref=pd_sbs_1/262-6485344-6957429?pd_rd_w=XJWhm&pf_rd_p=c90ec214-58e5-4089-9469-cee2bb7b5d96&pf_rd_r=JCC1960WCAT3HHMP9Q0E&pd_rd_r=1c39f0f3-c3dd-4b88-ba9c-9eb848a741d4&pd_rd_wg=WTZVp&pd_rd_i=0008402787&psc=1", "George R.R. Martin", 1, "/images/books/Fire_and_blood.jpg", 5L, "Centuries before A Game of Thrones, an even greater game began, one that set the skies alight with dragon flame and saw the Seven Kingdoms turned to ash. So began the Targaryens’ bloody rule, with fire and blood. Setting brother against brother, mother against daughter, and dragon against dragon. Chronicled by a learned maester of the Citadel, this thrilling and bloody history of Westeros tells the story of where the battle for the Iron Throne began…", "Fire and Blood", null },
                    { 15, "https://www.amazon.co.uk/Mice-Men-Penguin-Red-Classics/dp/0141023570/ref=sr_1_1?keywords=Of+Mice+and+Men+by+John+Steinbeck&qid=1638546894&s=books&sr=1-1", "John Steinbeck", 6, "/images/books/Of_Mice_and_Men.jpg", 6L, "Drifters in search of work, George and his childlike friend Lennie, have nothing in the world except the clothes on their back - and a dream that one day they will have some land of their own. Eventually they find work on a ranch in California's Salinas Valley, but their hopes are dashed as Lennie - struggling against extreme cruelty, misunderstanding and feelings of jealousy - becomes a victim of his own strength. Tackling universal themes of friendship and shared vision, and giving a voice to America's lonely and dispossessed, Of Mice and Men remains Steinbeck's most popular work, achieving success as a novel, Broadway play and three acclaimed films.", "Of Mice and Men", null },
                    { 13, "https://www.amazon.co.uk/Rita-Hayworth-and-Shawshank-Redemption/dp/1982155752/ref=sr_1_5?keywords=Shawshank+Redemption+book&qid=1638545684&sr=8-5", "Stephen King", 0, "/images/books/Rita_Hayworth_and_Shawshank_Redemption.jpg", 9L, "1 New York Times bestselling author Stephen King’s beloved novella, Rita Hayworth and Shawshank Redemption—the basis for the Best Picture Academy Award–nominee The Shawshank Redemption—about an unjustly imprisoned convict who seeks a strangely satisfying revenge, is now available for the first time as a standalone book.A mesmerizing tale of unjust imprisonment and offbeat escape, Rita Hayworth and Shawshank Redemption is one of Stephen King’s most beloved and iconic stories, and it helped make Castle Rock a place readers would * to over and over again.", "Rita Hayworth and Shawshank Redemption", null },
                    { 12, "https://www.amazon.co.uk/James-Joyce-Ulysses-Penguin-Classics/dp/B00I611LBM/ref=sr_1_1?crid=6VV1MUKPR88A&keywords=ulysses+james+joyce+penguin&qid=1638530666&s=books&sprefix=ulysses+james+joyce+pen%2Cstripbooks%2C150&sr=1-1", "James Joyce", 8, "/images/books/ulysses.png", 12L, "Ulysses follows Leopold Bloom as he goes from place to place in Dublin over the course of June 16, 1904, from 8 a.m. until 3 a.m. Joyce chose that particular day because it wasthe day of his first date with his wife, Nora Barnacle.", "Ulysses", null },
                    { 11, "https://www.amazon.co.uk/Dead-Souls-Nikolai-Gogol/dp/B084DGQKDS/ref=sr_1_1_sspa?keywords=Dead+Souls&qid=1638530381&sr=8-1-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUFKMVBQRzk3NU9MRk0mZW5jcnlwdGVkSWQ9QTA5OTU2MTZTNDgxSFBQNFhNVEgmZW5jcnlwdGVkQWRJZD1BMDgwMjgxMjFRMDI3MUdYUVhHUTAmd2lkZ2V0TmFtZT1zcF9hdGYmYWN0aW9uPWNsaWNrUmVkaXJlY3QmZG9Ob3RMb2dDbGljaz10cnVl", "Nikolai Gogol", 0, "/images/books/deadsouls.png", 10L, "Dead Souls Summary Dead Souls, by Nikolai Gogol, is a satirical examination of 1800's Russian nobility and society. The work is often called Gogol's greatest. It is also considered a Russian prose poem. In post-Napoleonic Russia, landowners owned serfs who worked the land.", "Dead Souls", null },
                    { 10, "https://www.amazon.co.uk/Midnights-Children-Vintage-Classics-Rushdie/dp/0099511894/ref=sr_1_1?crid=2BA0EOIER0WQP&keywords=midnight+children+by+salman+rushdie&qid=1638530052&sprefix=midnight+ch%2Caps%2C170&sr=8-1", "Salman Rushdie", 9, "/images/books/Midnight.png", 8L, "Midnight children covers the experiences of three generations of a Sinai family living in Srinagar Amritsar and Agra and then in Bombay and finally migrating to Karachi. Saleem Sinai is the narrator of the events. He works in a pickle factory by day and records his experiences by night.", "Midnights Children", null },
                    { 9, "https://www.amazon.co.uk/Invisible-Man-Penguin-Modern-Classics/dp/0141184426/ref=sr_1_1?crid=3GBXQS9JTZZ2Q&keywords=invisible+man+ralph+ellison&qid=1638529783&sprefix=invisible+man%2Caps%2C189&sr=8-1", "Ralph Ellison", 0, "/images/books/invisibleman.png", 6L, "Invisible Man is the story of a young black man from the South who does not fully understand racism in the world. Filled with hope about his future, he goes to college, but gets expelled for showing one of the white benefactors the real and seamy side of black existence.", "Invisible Man", null },
                    { 8, "https://www.amazon.co.uk/Trial-Legend-Classics-Franz-Kafka/dp/1789559529/ref=sr_1_2_sspa?keywords=the+trial&qid=1638529616&sr=8-2-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUExTFpIOVdCQlpHS0c2JmVuY3J5cHRlZElkPUEwNjA2MjIwRDhYQklHU0xaNldDJmVuY3J5cHRlZEFkSWQ9QTA1MTM5MTQxUzMyNkIxRFo2RDBFJndpZGdldE5hbWU9c3BfYXRmJmFjdGlvbj1jbGlja1JlZGlyZWN0JmRvTm90TG9nQ2xpY2s9dHJ1ZQ==", "Franz Kafka", 0, "/images/books/thetrial.png", 7L, "The Trial is the chronicle of that intervening year of K.'s case, his struggles and encounters with the invisible Law and the untouchable Court. It is an account, ultimately, of state-induced self-destruction. Yet, as in all of Kafka's best writing, the 'meaning' is far from clear.", "The Trial", null },
                    { 7, "https://www.amazon.co.uk/Stranger-Albert-Camus-Paperback/dp/B01181UBSU/ref=sr_1_3?crid=6SCM9M2XABXI&keywords=the+stranger+book+albert+camus&qid=1638529430&sprefix=the+stranger+book%2Cstripbooks%2C167&sr=8-3", "Albert Camus", 7, "/images/books/thestranger.png", 20L, "The Stranger tells the strange and baffling story of a young shipping clerk, Meursault, and the surprising ways he reacts to the world around him.", "The Stranger", null },
                    { 14, "https://www.amazon.co.uk/Notebook-Sparks-Nicholas-Paperback/dp/B00IIB02QK/ref=sr_1_3?crid=31BQIM5HJB63N&keywords=the+notebook+nicholas+sparks&qid=1638546490&s=books&sprefix=the+notebook+ni%2Cstripbooks%2C188&sr=1-3", "Nicholas Sparks", 3, "/images/books/The_Notebook.jpg", 6L, "The Notebook is the love story to end all love stories - it will break your heart, heal it back up and break it all over again.", "The Notebook", null },
                    { 6, "https://www.amazon.co.uk/Hamlet-William-Shakespeare/dp/B09JJJ7234/ref=sr_1_1_sspa?crid=Y8TUQY6FUX5R&keywords=hamlet+book&qid=1638529096&s=books&sprefix=hamlet%2Cstripbooks%2C172&sr=1-1-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUFQSFNPUlJZNURZOE8mZW5jcnlwdGVkSWQ9QTAwMzY3NDU3ODk4SFAxRENNUDEmZW5jcnlwdGVkQWRJZD1BMDMyNjk2MklETVBCTUxCMzZSVyZ3aWRnZXROYW1lPXNwX2F0ZiZhY3Rpb249Y2xpY2tSZWRpcmVjdCZkb05vdExvZ0NsaWNrPXRydWU=", "William Shakespeare", 6, "/images/books/hamlet.png", 7L, "Prince Hamlet is depressed. Having been summoned home to Denmark from school in Germany to attend his father's funeral, he is shocked to find his mother Gertrude already remarried. The Queen has wed Hamlet's Uncle Claudius, the dead king's brother.", "Hamlet", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 20);

            migrationBuilder.DropColumn(
                name: "BookGenre",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                columns: new[] { "AmazonLink", "Author", "PictureUrl", "Synopsis", "Title" },
                values: new object[] { "https://www.amazon.co.uk/Hunger-Games-Trilogy-Suzanne-Collins/dp/1407135449/ref=sr_1_11?keywords=hunger+games+book+1&qid=1638371618&sr=8-11", "Suzanne Collins", "/Data/BookImages/The-Hunger-Games.jpg", "In the ruins of a place once known as North America lies the nation of Panem, a shining Capitol surrounded by twelve outlying districts. The Capitol is harsh and cruel and keeps the districts in line by forcing them all to send one boy and one girl between the ages of twelve and eighteen to participate in the annual Hunger Games, a fight to the death on live TV.Sixteen-year-old Katniss Everdeen, who lives alone with her mother and younger sister, regards it as a death sentence when she steps forward to take her sister's place in the Games. But Katniss has been close to dead before—and survival, for her, is second nature. Without really meaning to, she becomes a contender. But if she is to win, she will have to start making choices that weight survival against humanity and life against love.", "The Hunger Games" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4,
                columns: new[] { "AmazonLink", "Author", "PictureUrl", "Synopsis", "Title" },
                values: new object[] { "https://www.amazon.co.uk/East-Eden-John-Steinbeck/dp/0670287385", "John Steinbeck", "https://bookaudio.online/uploads/images/media/184/jT_yinMH8Xl8UiU3-john-steinbeck-east-of-eden.jpg", "In the ruins of a place once known as North America lies the nation of Panem, a shining Capitol surrounded by twelve outlying districts. The Capitol is harsh and cruel and keeps the districts in line by forcing them all to send one boy and one girl between the ages of twelve and eighteen to participate in the annual Hunger Games, a fight to the death on live TV.Sixteen-year-old Katniss Everdeen, who lives alone with her mother and younger sister, regards it as a death sentence when she steps forward to take her sister's place in the Games. But Katniss has been close to dead before—and survival, for her, is second nature. Without really meaning to, she becomes a contender. But if she is to win, she will have to start making choices that weight survival against humanity and life against love.", "East of Eden" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5,
                columns: new[] { "AmazonLink", "Author", "PictureUrl", "Synopsis", "Title" },
                values: new object[] { "https://www.amazon.co.uk/Pride-Prejudice-Alma-Classics-Evergreens/dp/1847493696/ref=asc_df_1847493696?tag=bingshoppinga-21&linkCode=df0&hvadid=80401845130311&hvnetw=o&hvqmt=e&hvbmt=be&hvdev=c&hvlocint=&hvlocphy=&hvtargid=pla-4584001419445871&psc=1", "Jane Austen", "https://almabooks.com/wp-content/uploads/2016/10/9781847493699.jpg", "The pride of high-ranking Mr Darcy and the prejudice of middle-class Elizabeth Bennet conduct an absorbing dance through the rigid social hierarchies of early-nineteenth-century England, with the passion of the two unlikely lovers growing as their union seems ever more improbable.", "Pride and Prejudice" });
        }
    }
}