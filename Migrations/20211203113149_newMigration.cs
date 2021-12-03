using Microsoft.EntityFrameworkCore.Migrations;

namespace YJKBooks.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Books",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Books",
                newName: "Synopsis");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PictureUrl",
                value: "/images/products/Pride.png");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BookGenre", "Link", "PictureUrl", "Price", "Synopsis", "Title", "UsersId" },
                values: new object[,]
                {
                    { 4, "Leo Tolsoy", 4, "https://www.amazon.co.uk/Anna-Karenina-Wordsworth-Classics-Tolstoy/dp/1853262714", "/images/products/Anna.png", 12L, "Anna Karenina tells of the doomed love affair between the sensuous and rebellious Anna and the dashing officer, Count Vronsky. Tragedy unfolds as Anna rejects her passionless marriage and must endure the hypocrisies of society. Set against a vast and richly textured canvas of nineteenth-century Russia, the novel's seven major characters create a dynamic imbalance, playing out the contrasts of city and country life and all the variations on love and family happiness. While previous versions have softened the robust, and sometimes shocking, quality of Tolstoy's writing, Pevear and Volokhonsky have produced a translation true to his powerful voice. This award-winning team's authoritative edition also includes an illuminating introduction and explanatory notes. Beautiful, vigorous, and eminently readable, this Anna Karenina will be the definitive text for generations to come.", "Anna Karenina", null },
                    { 5, "George Orwell", 5, "https://www.amazon.co.uk/1984-Nineteen-Eighty-Four-Twentieth-Masterpiece/dp/184697576X/ref=sr_1_1_sspa?crid=3SC3VA96NF93Z&keywords=1984+george+orwell&qid=1638528594&s=books&sprefix=1984%2Cstripbooks%2C164&sr=1-1-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUEzTkRPWkQ4MDNLMlpQJmVuY3J5cHRlZElkPUEwODI1NzI1MVkzWUFEWUhTMVM1TCZlbmNyeXB0ZWRBZElkPUEwNjk5MzU2RFNJSTdLSjlKVUU0JndpZGdldE5hbWU9c3BfYXRmJmFjdGlvbj1jbGlja1JlZGlyZWN0JmRvTm90TG9nQ2xpY2s9dHJ1ZQ==", "/images/products/1984.png", 5L, "Winston Smith attempts to fights back against a totalitarian Party that rules Oceania and his entire life. It is a dystopian novel that tells the story of Winston Smith and warns of the dangers of a totalitarian government that rules through fear, surveillance, propaganda, and brainwashing.", "1984", null },
                    { 6, "William Shakespeare", 6, "https://www.amazon.co.uk/Hamlet-William-Shakespeare/dp/B09JJJ7234/ref=sr_1_1_sspa?crid=Y8TUQY6FUX5R&keywords=hamlet+book&qid=1638529096&s=books&sprefix=hamlet%2Cstripbooks%2C172&sr=1-1-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUFQSFNPUlJZNURZOE8mZW5jcnlwdGVkSWQ9QTAwMzY3NDU3ODk4SFAxRENNUDEmZW5jcnlwdGVkQWRJZD1BMDMyNjk2MklETVBCTUxCMzZSVyZ3aWRnZXROYW1lPXNwX2F0ZiZhY3Rpb249Y2xpY2tSZWRpcmVjdCZkb05vdExvZ0NsaWNrPXRydWU=", "/images/products/Hamlet.png", 7L, "Prince Hamlet is depressed. Having been summoned home to Denmark from school in Germany to attend his father's funeral, he is shocked to find his mother Gertrude already remarried. The Queen has wed Hamlet's Uncle Claudius, the dead king's brother.", "Hamlet", null },
                    { 7, "Albert Camus", 7, "https://www.amazon.co.uk/Stranger-Albert-Camus-Paperback/dp/B01181UBSU/ref=sr_1_3?crid=6SCM9M2XABXI&keywords=the+stranger+book+albert+camus&qid=1638529430&sprefix=the+stranger+book%2Cstripbooks%2C167&sr=8-3", "/images/products/Stranger.png", 20L, "The Stranger tells the strange and baffling story of a young shipping clerk, Meursault, and the surprising ways he reacts to the world around him.", "The Stranger", null },
                    { 8, "Franz Kafka", 0, "https://www.amazon.co.uk/Trial-Legend-Classics-Franz-Kafka/dp/1789559529/ref=sr_1_2_sspa?keywords=the+trial&qid=1638529616&sr=8-2-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUExTFpIOVdCQlpHS0c2JmVuY3J5cHRlZElkPUEwNjA2MjIwRDhYQklHU0xaNldDJmVuY3J5cHRlZEFkSWQ9QTA1MTM5MTQxUzMyNkIxRFo2RDBFJndpZGdldE5hbWU9c3BfYXRmJmFjdGlvbj1jbGlja1JlZGlyZWN0JmRvTm90TG9nQ2xpY2s9dHJ1ZQ==", "/images/products/Trial.png", 7L, "The Trial is the chronicle of that intervening year of K.'s case, his struggles and encounters with the invisible Law and the untouchable Court. It is an account, ultimately, of state-induced self-destruction. Yet, as in all of Kafka's best writing, the 'meaning' is far from clear.", "The Trial", null },
                    { 9, "Ralph Ellison", 0, "https://www.amazon.co.uk/Invisible-Man-Penguin-Modern-Classics/dp/0141184426/ref=sr_1_1?crid=3GBXQS9JTZZ2Q&keywords=invisible+man+ralph+ellison&qid=1638529783&sprefix=invisible+man%2Caps%2C189&sr=8-1", "/images/products/Invisible.png", 6L, "Invisible Man is the story of a young black man from the South who does not fully understand racism in the world. Filled with hope about his future, he goes to college, but gets expelled for showing one of the white benefactors the real and seamy side of black existence.", "Invisible Man", null },
                    { 10, "Salman Rushdie", 9, "https://www.amazon.co.uk/Midnights-Children-Vintage-Classics-Rushdie/dp/0099511894/ref=sr_1_1?crid=2BA0EOIER0WQP&keywords=midnight+children+by+salman+rushdie&qid=1638530052&sprefix=midnight+ch%2Caps%2C170&sr=8-1", "/images/products/Midnight.png", 8L, "Midnight children covers the experiences of three generations of a Sinai family living in Srinagar Amritsar and Agra and then in Bombay and finally migrating to Karachi. Saleem Sinai is the narrator of the events. He works in a pickle factory by day and records his experiences by night.", "Midnights Children", null },
                    { 11, "Nikolai Gogol", 0, "https://www.amazon.co.uk/Dead-Souls-Nikolai-Gogol/dp/B084DGQKDS/ref=sr_1_1_sspa?keywords=Dead+Souls&qid=1638530381&sr=8-1-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUFKMVBQRzk3NU9MRk0mZW5jcnlwdGVkSWQ9QTA5OTU2MTZTNDgxSFBQNFhNVEgmZW5jcnlwdGVkQWRJZD1BMDgwMjgxMjFRMDI3MUdYUVhHUTAmd2lkZ2V0TmFtZT1zcF9hdGYmYWN0aW9uPWNsaWNrUmVkaXJlY3QmZG9Ob3RMb2dDbGljaz10cnVl", "/images/products/Deadsouls.png", 10L, "Dead Souls Summary Dead Souls, by Nikolai Gogol, is a satirical examination of 1800's Russian nobility and society. The work is often called Gogol's greatest. It is also considered a Russian prose poem. In post-Napoleonic Russia, landowners owned serfs who worked the land.", "Dead Souls", null },
                    { 12, "James Joyce", 8, "https://www.amazon.co.uk/James-Joyce-Ulysses-Penguin-Classics/dp/B00I611LBM/ref=sr_1_1?crid=6VV1MUKPR88A&keywords=ulysses+james+joyce+penguin&qid=1638530666&s=books&sprefix=ulysses+james+joyce+pen%2Cstripbooks%2C150&sr=1-1", "/images/products/Ulysses.png", 12L, "Ulysses follows Leopold Bloom as he goes from place to place in Dublin over the course of June 16, 1904, from 8 a.m. until 3 a.m. Joyce chose that particular day because it wasthe day of his first date with his wife, Nora Barnacle.", "Ulysses", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Books",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Synopsis",
                table: "Books",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PictureUrl",
                value: "https://almabooks.com/wp-content/uploads/2016/10/9781847493699.jpg");
        }
    }
}
