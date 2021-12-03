using Microsoft.EntityFrameworkCore.Migrations;

namespace YJKBooks.Migrations
{
    public partial class TheodorabookMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PictureUrl",
                value: "/images/books/Pride.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "PictureUrl",
                value: "/images/books/Anna.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "PictureUrl",
                value: "/images/books/1984.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "PictureUrl",
                value: "/images/books/Hamlet.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "PictureUrl",
                value: "/images/books/Stranger.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "PictureUrl",
                value: "/images/books/Trial.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "PictureUrl",
                value: "/images/books/Invisible.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "PictureUrl",
                value: "/images/books/Midnight.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "PictureUrl",
                value: "/images/books/Deadsouls.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "PictureUrl",
                value: "/images/books/Ulysses.png");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BookGenre", "Link", "PictureUrl", "Price", "Synopsis", "Title", "UsersId" },
                values: new object[,]
                {
                    { 19, "Suzanne Collins", 0, "https://www.amazon.co.uk/Hunger-Games-Trilogy-Suzanne-Collins/dp/1407135449/ref=sr_1_11?keywords=hunger+games+book+1&qid=1638371618&sr=8-11", "/images/books/The-Hunger-Games.jpg", 17L, "In the ruins of a place once known as North America lies the nation of Panem, a shining Capitol surrounded by twelve outlying districts. The Capitol is harsh and cruel and keeps the districts in line by forcing them all to send one boy and one girl between the ages of twelve and eighteen to participate in the annual Hunger Games, a fight to the death on live TV.Sixteen-year-old Katniss Everdeen, who lives alone with her mother and younger sister, regards it as a death sentence when she steps forward to take her sister's place in the Games. But Katniss has been close to dead before—and survival, for her, is second nature. Without really meaning to, she becomes a contender. But if she is to win, she will have to start making choices that weight survival against humanity and life against love.", "The Hunger Games", null },
                    { 18, "Richard Osman", 0, "https://www.amazon.co.uk/s?k=the+man+who+died+twice+richard+osman&i=stripbooks&crid=3Q844228FAPDJ&sprefix=The+men+who+di%2Cstripbooks%2C176&ref=nb_sb_ss_sc_1_14", "/images/books/The man who dies twice.jpg", 9L, "Elizabeth has received a letter from an old colleague, a man with whom she has a long history. He's made a big mistake, and he needs her help. His story involves stolen diamonds, a violent mobster, and a very real threat to his life.As bodies start piling up, Elizabeth enlists Joyce, Ibrahim and Ron in the hunt for a ruthless murderer. And if they find the diamonds too? Well, wouldn't that be a bonus?But this time they are up against an enemy who wouldn't bat an eyelid at knocking off four septuagenarians. Can the Thursday Murder Club find the killer (and the diamonds) before the killer finds them?", "The Man Who Died Twice ", null },
                    { 17, "Plato", 7, "https://www.amazon.co.uk/Republic-Penguin-Classics-Plato/dp/0140455116/ref=sr_1_3?crid=2WSL8U42WFLDJ&keywords=plato+republic&qid=1638547554&s=books&sprefix=plato+%2Cstripbooks%2C502&sr=1-3", "/images/books/The Republic.jpg", 7L, "Plato's Republic is widely acknowledged as one of the most influential works in the history of philosophy. Presented in the form of a dialogue between Socrates and three different interlocutors, it is an inquiry into the notion of a perfect community and the ideal individual within it. During the conversation other questions are raised: what is goodness; what is reality; what is knowledge; what is the purpose of education? With remarkable lucidity and deft use of allegory, Plato arrives at a depiction of a state bound by harmony and ruled by 'philosopher kings'.", "The Republic", null },
                    { 16, "George R.R. Martin", 1, "https://www.amazon.co.uk/Fire-Blood-Thrones-Targaryen-History/dp/0008402787/ref=pd_sbs_1/262-6485344-6957429?pd_rd_w=XJWhm&pf_rd_p=c90ec214-58e5-4089-9469-cee2bb7b5d96&pf_rd_r=JCC1960WCAT3HHMP9Q0E&pd_rd_r=1c39f0f3-c3dd-4b88-ba9c-9eb848a741d4&pd_rd_wg=WTZVp&pd_rd_i=0008402787&psc=1", "/images/books/Fire and blood.jpg", 5L, "Centuries before A Game of Thrones, an even greater game began, one that set the skies alight with dragon flame and saw the Seven Kingdoms turned to ash. So began the Targaryens’ bloody rule, with fire and blood. Setting brother against brother, mother against daughter, and dragon against dragon. Chronicled by a learned maester of the Citadel, this thrilling and bloody history of Westeros tells the story of where the battle for the Iron Throne began…", "Fire and Blood", null },
                    { 15, "John Steinbeck", 6, "https://www.amazon.co.uk/Mice-Men-Penguin-Red-Classics/dp/0141023570/ref=sr_1_1?keywords=Of+Mice+and+Men+by+John+Steinbeck&qid=1638546894&s=books&sr=1-1", "/images/books/Of Mice and Men.jpg", 6L, "Drifters in search of work, George and his childlike friend Lennie, have nothing in the world except the clothes on their back - and a dream that one day they will have some land of their own. Eventually they find work on a ranch in California's Salinas Valley, but their hopes are dashed as Lennie - struggling against extreme cruelty, misunderstanding and feelings of jealousy - becomes a victim of his own strength. Tackling universal themes of friendship and shared vision, and giving a voice to America's lonely and dispossessed, Of Mice and Men remains Steinbeck's most popular work, achieving success as a novel, Broadway play and three acclaimed films.", "Of Mice and Men", null },
                    { 14, "Nicholas Sparks", 3, "https://www.amazon.co.uk/Notebook-Sparks-Nicholas-Paperback/dp/B00IIB02QK/ref=sr_1_3?crid=31BQIM5HJB63N&keywords=the+notebook+nicholas+sparks&qid=1638546490&s=books&sprefix=the+notebook+ni%2Cstripbooks%2C188&sr=1-3", "/images/books/The_Notebook.jpg", 6L, "The Notebook is the love story to end all love stories - it will break your heart, heal it back up and break it all over again.", "The Notebook", null },
                    { 20, "John Steinbeck", 0, "https://www.amazon.co.uk/East-Eden-John-Steinbeck/dp/0670287385", "https://bookaudio.online/uploads/images/media/184/jT_yinMH8Xl8UiU3-john-steinbeck-east-of-eden.jpg", 61L, "In the ruins of a place once known as North America lies the nation of Panem, a shining Capitol surrounded by twelve outlying districts. The Capitol is harsh and cruel and keeps the districts in line by forcing them all to send one boy and one girl between the ages of twelve and eighteen to participate in the annual Hunger Games, a fight to the death on live TV.Sixteen-year-old Katniss Everdeen, who lives alone with her mother and younger sister, regards it as a death sentence when she steps forward to take her sister's place in the Games. But Katniss has been close to dead before—and survival, for her, is second nature. Without really meaning to, she becomes a contender. But if she is to win, she will have to start making choices that weight survival against humanity and life against love.", "East of Eden", null },
                    { 13, "Stephen King", 0, "https://www.amazon.co.uk/Rita-Hayworth-and-Shawshank-Redemption/dp/1982155752/ref=sr_1_5?keywords=Shawshank+Redemption+book&qid=1638545684&sr=8-5", "/images/books/Rita Hayworth and Shawshank Redemption.jpg", 9L, "1 New York Times bestselling author Stephen King’s beloved novella, Rita Hayworth and Shawshank Redemption—the basis for the Best Picture Academy Award–nominee The Shawshank Redemption—about an unjustly imprisoned convict who seeks a strangely satisfying revenge, is now available for the first time as a standalone book.A mesmerizing tale of unjust imprisonment and offbeat escape, Rita Hayworth and Shawshank Redemption is one of Stephen King’s most beloved and iconic stories, and it helped make Castle Rock a place readers would * to over and over again.", "Rita Hayworth and Shawshank Redemption", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PictureUrl",
                value: "/images/products/Pride.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "PictureUrl",
                value: "/images/products/Anna.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "PictureUrl",
                value: "/images/products/1984.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "PictureUrl",
                value: "/images/products/Hamlet.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "PictureUrl",
                value: "/images/products/Stranger.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "PictureUrl",
                value: "/images/products/Trial.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "PictureUrl",
                value: "/images/products/Invisible.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "PictureUrl",
                value: "/images/products/Midnight.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "PictureUrl",
                value: "/images/products/Deadsouls.png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "PictureUrl",
                value: "/images/products/Ulysses.png");
        }
    }
}
