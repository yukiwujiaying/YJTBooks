using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YJKBooks.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookGenre = table.Column<string>(type: "nvarchar(24)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteBookList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteBookList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteBookList_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookListItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    FavouriteBookListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookListItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_BookListItem_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookListItem_FavouriteBookList_FavouriteBookListId",
                        column: x => x.FavouriteBookListId,
                        principalTable: "FavouriteBookList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BookGenre", "Link", "PictureUrl", "Price", "Synopsis", "Title" },
                values: new object[,]
                {
                    { 1, "J. R. R. Tolkien", "Fantasy", "https://www.amazon.co.uk/Hobbit-J-R-Tolkien/dp/0007458428/ref=asc_df_0007458428?tag=bingshoppinga-21&linkCode=df0&hvadid=80882880812450&hvnetw=o&hvqmt=e&hvbmt=be&hvdev=c&hvlocint=&hvlocphy=&hvtargid=pla-4584482456235141&psc=1", "http://4.bp.blogspot.com/-Q2jfDj24R9Q/UMX-5B1zJ2I/AAAAAAAAAHw/0rOGgxaYtnw/s1600/The+Hobbit.jpg", 6.5499999999999998, "Bilbo Baggins enjoys a quiet and contented life, with no desire to travel far from the comforts of home; then one day the wizard Gandalf and a band of dwarves arrive unexpectedly and enlist his services – as a burglar – on a dangerous expedition to raid the treasure-hoard of Smaug the dragon. Bilbo’s life is never to be the same again.", "The Hobbit" },
                    { 18, "Richard Osman", "Fiction", "https://www.amazon.co.uk/s?k=the+man+who+died+twice+richard+osman&i=stripbooks&crid=3Q844228FAPDJ&sprefix=The+men+who+di%2Cstripbooks%2C176&ref=nb_sb_ss_sc_1_14", "/images/books/The man who dies twice.jpg", 9.0, "Elizabeth has received a letter from an old colleague, a man with whom she has a long history. He's made a big mistake, and he needs her help. His story involves stolen diamonds, a violent mobster, and a very real threat to his life.As bodies start piling up, Elizabeth enlists Joyce, Ibrahim and Ron in the hunt for a ruthless murderer. And if they find the diamonds too? Well, wouldn't that be a bonus?But this time they are up against an enemy who wouldn't bat an eyelid at knocking off four septuagenarians. Can the Thursday Murder Club find the killer (and the diamonds) before the killer finds them?", "The Man Who Died Twice " },
                    { 17, "Plato", "Philosophical", "https://www.amazon.co.uk/Republic-Penguin-Classics-Plato/dp/0140455116/ref=sr_1_3?crid=2WSL8U42WFLDJ&keywords=plato+republic&qid=1638547554&s=books&sprefix=plato+%2Cstripbooks%2C502&sr=1-3", "/images/books/The Republic.jpg", 7.1900000000000004, "Plato's Republic is widely acknowledged as one of the most influential works in the history of philosophy. Presented in the form of a dialogue between Socrates and three different interlocutors, it is an inquiry into the notion of a perfect community and the ideal individual within it. During the conversation other questions are raised: what is goodness; what is reality; what is knowledge; what is the purpose of education? With remarkable lucidity and deft use of allegory, Plato arrives at a depiction of a state bound by harmony and ruled by 'philosopher kings'.", "The Republic" },
                    { 16, "George R.R. Martin", "Fantasy", "https://www.amazon.co.uk/Fire-Blood-Thrones-Targaryen-History/dp/0008402787/ref=pd_sbs_1/262-6485344-6957429?pd_rd_w=XJWhm&pf_rd_p=c90ec214-58e5-4089-9469-cee2bb7b5d96&pf_rd_r=JCC1960WCAT3HHMP9Q0E&pd_rd_r=1c39f0f3-c3dd-4b88-ba9c-9eb848a741d4&pd_rd_wg=WTZVp&pd_rd_i=0008402787&psc=1", "/images/books/Fire and blood.jpg", 5.9900000000000002, "Centuries before A Game of Thrones, an even greater game began, one that set the skies alight with dragon flame and saw the Seven Kingdoms turned to ash. So began the Targaryens’ bloody rule, with fire and blood. Setting brother against brother, mother against daughter, and dragon against dragon. Chronicled by a learned maester of the Citadel, this thrilling and bloody history of Westeros tells the story of where the battle for the Iron Throne began…", "Fire and Blood" },
                    { 15, "John Steinbeck", "Tragedy", "https://www.amazon.co.uk/Mice-Men-Penguin-Red-Classics/dp/0141023570/ref=sr_1_1?keywords=Of+Mice+and+Men+by+John+Steinbeck&qid=1638546894&s=books&sr=1-1", "/images/books/Of Mice and Men.jpg", 6.9900000000000002, "Drifters in search of work, George and his childlike friend Lennie, have nothing in the world except the clothes on their back - and a dream that one day they will have some land of their own. Eventually they find work on a ranch in California's Salinas Valley, but their hopes are dashed as Lennie - struggling against extreme cruelty, misunderstanding and feelings of jealousy - becomes a victim of his own strength. Tackling universal themes of friendship and shared vision, and giving a voice to America's lonely and dispossessed, Of Mice and Men remains Steinbeck's most popular work, achieving success as a novel, Broadway play and three acclaimed films.", "Of Mice and Men" },
                    { 14, "Nicholas Sparks", "Romance", "https://www.amazon.co.uk/Notebook-Sparks-Nicholas-Paperback/dp/B00IIB02QK/ref=sr_1_3?crid=31BQIM5HJB63N&keywords=the+notebook+nicholas+sparks&qid=1638546490&s=books&sprefix=the+notebook+ni%2Cstripbooks%2C188&sr=1-3", "/images/books/The_Notebook.jpg", 6.6900000000000004, "The Notebook is the love story to end all love stories - it will break your heart, heal it back up and break it all over again.", "The Notebook" },
                    { 13, "Stephen King", "Fiction", "https://www.amazon.co.uk/Rita-Hayworth-and-Shawshank-Redemption/dp/1982155752/ref=sr_1_5?keywords=Shawshank+Redemption+book&qid=1638545684&sr=8-5", "/images/books/Rita Hayworth and Shawshank Redemption.jpg", 9.7799999999999994, "1 New York Times bestselling author Stephen King’s beloved novella, Rita Hayworth and Shawshank Redemption—the basis for the Best Picture Academy Award–nominee The Shawshank Redemption—about an unjustly imprisoned convict who seeks a strangely satisfying revenge, is now available for the first time as a standalone book.A mesmerizing tale of unjust imprisonment and offbeat escape, Rita Hayworth and Shawshank Redemption is one of Stephen King’s most beloved and iconic stories, and it helped make Castle Rock a place readers would * to over and over again.", "Rita Hayworth and Shawshank Redemption" },
                    { 12, "James Joyce", "Modernist", "https://www.amazon.co.uk/James-Joyce-Ulysses-Penguin-Classics/dp/B00I611LBM/ref=sr_1_1?crid=6VV1MUKPR88A&keywords=ulysses+james+joyce+penguin&qid=1638530666&s=books&sprefix=ulysses+james+joyce+pen%2Cstripbooks%2C150&sr=1-1", "/images/books/Ulysses.png", 12.69, "Ulysses follows Leopold Bloom as he goes from place to place in Dublin over the course of June 16, 1904, from 8 a.m. until 3 a.m. Joyce chose that particular day because it wasthe day of his first date with his wife, Nora Barnacle.", "Ulysses" },
                    { 11, "Nikolai Gogol", "Fiction", "https://www.amazon.co.uk/Dead-Souls-Nikolai-Gogol/dp/B084DGQKDS/ref=sr_1_1_sspa?keywords=Dead+Souls&qid=1638530381&sr=8-1-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUFKMVBQRzk3NU9MRk0mZW5jcnlwdGVkSWQ9QTA5OTU2MTZTNDgxSFBQNFhNVEgmZW5jcnlwdGVkQWRJZD1BMDgwMjgxMjFRMDI3MUdYUVhHUTAmd2lkZ2V0TmFtZT1zcF9hdGYmYWN0aW9uPWNsaWNrUmVkaXJlY3QmZG9Ob3RMb2dDbGljaz10cnVl", "/images/books/Deadsouls.png", 10.99, "Dead Souls Summary Dead Souls, by Nikolai Gogol, is a satirical examination of 1800's Russian nobility and society. The work is often called Gogol's greatest. It is also considered a Russian prose poem. In post-Napoleonic Russia, landowners owned serfs who worked the land.", "Dead Souls" },
                    { 10, "Salman Rushdie", "MagicRealism", "https://www.amazon.co.uk/Midnights-Children-Vintage-Classics-Rushdie/dp/0099511894/ref=sr_1_1?crid=2BA0EOIER0WQP&keywords=midnight+children+by+salman+rushdie&qid=1638530052&sprefix=midnight+ch%2Caps%2C170&sr=8-1", "/images/books/Midnight.png", 8.1899999999999995, "Midnight children covers the experiences of three generations of a Sinai family living in Srinagar Amritsar and Agra and then in Bombay and finally migrating to Karachi. Saleem Sinai is the narrator of the events. He works in a pickle factory by day and records his experiences by night.", "Midnights Children" },
                    { 9, "Ralph Ellison", "Fiction", "https://www.amazon.co.uk/Invisible-Man-Penguin-Modern-Classics/dp/0141184426/ref=sr_1_1?crid=3GBXQS9JTZZ2Q&keywords=invisible+man+ralph+ellison&qid=1638529783&sprefix=invisible+man%2Caps%2C189&sr=8-1", "/images/books/Invisible.png", 6.9900000000000002, "Invisible Man is the story of a young black man from the South who does not fully understand racism in the world. Filled with hope about his future, he goes to college, but gets expelled for showing one of the white benefactors the real and seamy side of black existence.", "Invisible Man" },
                    { 8, "Franz Kafka", "Fiction", "https://www.amazon.co.uk/Trial-Legend-Classics-Franz-Kafka/dp/1789559529/ref=sr_1_2_sspa?keywords=the+trial&qid=1638529616&sr=8-2-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUExTFpIOVdCQlpHS0c2JmVuY3J5cHRlZElkPUEwNjA2MjIwRDhYQklHU0xaNldDJmVuY3J5cHRlZEFkSWQ9QTA1MTM5MTQxUzMyNkIxRFo2RDBFJndpZGdldE5hbWU9c3BfYXRmJmFjdGlvbj1jbGlja1JlZGlyZWN0JmRvTm90TG9nQ2xpY2s9dHJ1ZQ==", "/images/books/Trial.png", 7.79, "The Trial is the chronicle of that intervening year of K.'s case, his struggles and encounters with the invisible Law and the untouchable Court. It is an account, ultimately, of state-induced self-destruction. Yet, as in all of Kafka's best writing, the 'meaning' is far from clear.", "The Trial" },
                    { 7, "Albert Camus", "Philosophical", "https://www.amazon.co.uk/Stranger-Albert-Camus-Paperback/dp/B01181UBSU/ref=sr_1_3?crid=6SCM9M2XABXI&keywords=the+stranger+book+albert+camus&qid=1638529430&sprefix=the+stranger+book%2Cstripbooks%2C167&sr=8-3", "/images/books/Stranger.png", 20.32, "The Stranger tells the strange and baffling story of a young shipping clerk, Meursault, and the surprising ways he reacts to the world around him.", "The Stranger" },
                    { 6, "William Shakespeare", "Tragedy", "https://www.amazon.co.uk/Hamlet-William-Shakespeare/dp/B09JJJ7234/ref=sr_1_1_sspa?crid=Y8TUQY6FUX5R&keywords=hamlet+book&qid=1638529096&s=books&sprefix=hamlet%2Cstripbooks%2C172&sr=1-1-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUFQSFNPUlJZNURZOE8mZW5jcnlwdGVkSWQ9QTAwMzY3NDU3ODk4SFAxRENNUDEmZW5jcnlwdGVkQWRJZD1BMDMyNjk2MklETVBCTUxCMzZSVyZ3aWRnZXROYW1lPXNwX2F0ZiZhY3Rpb249Y2xpY2tSZWRpcmVjdCZkb05vdExvZ0NsaWNrPXRydWU=", "/images/books/Hamlet.png", 7.9900000000000002, "Prince Hamlet is depressed. Having been summoned home to Denmark from school in Germany to attend his father's funeral, he is shocked to find his mother Gertrude already remarried. The Queen has wed Hamlet's Uncle Claudius, the dead king's brother.", "Hamlet" },
                    { 5, "George Orwell", "SciFi", "https://www.amazon.co.uk/1984-Nineteen-Eighty-Four-Twentieth-Masterpiece/dp/184697576X/ref=sr_1_1_sspa?crid=3SC3VA96NF93Z&keywords=1984+george+orwell&qid=1638528594&s=books&sprefix=1984%2Cstripbooks%2C164&sr=1-1-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUEzTkRPWkQ4MDNLMlpQJmVuY3J5cHRlZElkPUEwODI1NzI1MVkzWUFEWUhTMVM1TCZlbmNyeXB0ZWRBZElkPUEwNjk5MzU2RFNJSTdLSjlKVUU0JndpZGdldE5hbWU9c3BfYXRmJmFjdGlvbj1jbGlja1JlZGlyZWN0JmRvTm90TG9nQ2xpY2s9dHJ1ZQ==", "/images/books/1984.png", 5.9900000000000002, "Winston Smith attempts to fights back against a totalitarian Party that rules Oceania and his entire life. It is a dystopian novel that tells the story of Winston Smith and warns of the dangers of a totalitarian government that rules through fear, surveillance, propaganda, and brainwashing.", "1984" },
                    { 4, "Leo Tolsoy", "Drama", "https://www.amazon.co.uk/Anna-Karenina-Wordsworth-Classics-Tolstoy/dp/1853262714", "/images/books/Anna.png", 12.99, "Anna Karenina tells of the doomed love affair between the sensuous and rebellious Anna and the dashing officer, Count Vronsky. Tragedy unfolds as Anna rejects her passionless marriage and must endure the hypocrisies of society. Set against a vast and richly textured canvas of nineteenth-century Russia, the novel's seven major characters create a dynamic imbalance, playing out the contrasts of city and country life and all the variations on love and family happiness. While previous versions have softened the robust, and sometimes shocking, quality of Tolstoy's writing, Pevear and Volokhonsky have produced a translation true to his powerful voice. This award-winning team's authoritative edition also includes an illuminating introduction and explanatory notes. Beautiful, vigorous, and eminently readable, this Anna Karenina will be the definitive text for generations to come.", "Anna Karenina" },
                    { 3, "Jane Austen", "Romance", "https://www.amazon.co.uk/Pride-Prejudice-Alma-Classics-Evergreens/dp/1847493696/ref=asc_df_1847493696?tag=bingshoppinga-21&linkCode=df0&hvadid=80401845130311&hvnetw=o&hvqmt=e&hvbmt=be&hvdev=c&hvlocint=&hvlocphy=&hvtargid=pla-4584001419445871&psc=1", "/images/books/Pride.png", 5.3899999999999997, "The pride of high-ranking Mr Darcy and the prejudice of middle-class Elizabeth Bennet conduct an absorbing dance through the rigid social hierarchies of early-nineteenth-century England, with the passion of the two unlikely lovers growing as their union seems ever more improbable.", "Pride and Prejudice" },
                    { 2, "J. R. R. Tolkien", "Fantasy", "https://www.amazon.co.uk/Lord-Rings-Boxed-Set/dp/0007581149/ref=asc_df_0007581149?tag=bingshoppinga-21&linkCode=df0&hvadid=80608002971184&hvnetw=o&hvqmt=e&hvbmt=be&hvdev=c&hvlocint=&hvlocphy=&hvtargid=pla-4584207578206752&psc=1", "http://d20eq91zdmkqd.cloudfront.net/assets/images/book/large/9780/0075/9780007581146.jpg", 39.990000000000002, "Sauron, the Dark Lord, has gathered to him all the Rings of Power – the means by which he intends to rule Middle-earth. All he lacks in his plans for dominion is the One Ring – the ring that rules them all – which has fallen into the hands of the hobbit, Bilbo Baggins. In a sleepy village in the Shire, young Frodo Baggins finds himself faced with an immense task, as the Ring is entrusted to his care. He must leave his home and make a perilous journey across the realms of Middle-earth to the Crack of Doom, deep inside the territories of the Dark Lord. There he must destroy the Ring forever and foil the Dark Lord in his evil purpose.", "The Lord of the Rings " },
                    { 19, "Suzanne Collins", "Fiction", "https://www.amazon.co.uk/Hunger-Games-Trilogy-Suzanne-Collins/dp/1407135449/ref=sr_1_11?keywords=hunger+games+book+1&qid=1638371618&sr=8-11", "/images/books/The-Hunger-Games.jpg", 17.09, "In the ruins of a place once known as North America lies the nation of Panem, a shining Capitol surrounded by twelve outlying districts. The Capitol is harsh and cruel and keeps the districts in line by forcing them all to send one boy and one girl between the ages of twelve and eighteen to participate in the annual Hunger Games, a fight to the death on live TV.Sixteen-year-old Katniss Everdeen, who lives alone with her mother and younger sister, regards it as a death sentence when she steps forward to take her sister's place in the Games. But Katniss has been close to dead before—and survival, for her, is second nature. Without really meaning to, she becomes a contender. But if she is to win, she will have to start making choices that weight survival against humanity and life against love.", "The Hunger Games" },
                    { 20, "John Steinbeck", "Fiction", "https://www.amazon.co.uk/East-Eden-John-Steinbeck/dp/0670287385", "https://bookaudio.online/uploads/images/media/184/jT_yinMH8Xl8UiU3-john-steinbeck-east-of-eden.jpg", 61.640000000000001, "In the ruins of a place once known as North America lies the nation of Panem, a shining Capitol surrounded by twelve outlying districts. The Capitol is harsh and cruel and keeps the districts in line by forcing them all to send one boy and one girl between the ages of twelve and eighteen to participate in the annual Hunger Games, a fight to the death on live TV.Sixteen-year-old Katniss Everdeen, who lives alone with her mother and younger sister, regards it as a death sentence when she steps forward to take her sister's place in the Games. But Katniss has been close to dead before—and survival, for her, is second nature. Without really meaning to, she becomes a contender. But if she is to win, she will have to start making choices that weight survival against humanity and life against love.", "East of Eden" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookListItem_BookId",
                table: "BookListItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookListItem_FavouriteBookListId",
                table: "BookListItem",
                column: "FavouriteBookListId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteBookList_UserId",
                table: "FavouriteBookList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookListItem");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FavouriteBookList");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
