﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YJKBooks.Contexts;

namespace YJKBooks.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220117171734_deleteForeignKeyOfFavouriteBookListInUserEntity")]
    partial class deleteForeignKeyOfFavouriteBookListInUserEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "9eba37fc-0565-4e4a-ad2b-8c34c379c871",
                            ConcurrencyStamp = "0346877f-e2b5-4987-95b6-fb324ff45432",
                            Name = "Member",
                            NormalizedName = "MEMBER"
                        },
                        new
                        {
                            Id = "8f73533d-4dbc-441d-8cad-15304d19c43a",
                            ConcurrencyStamp = "77dde8b0-993c-4718-81ad-b3c7a925220f",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("YJKBooks.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookGenre")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Synopsis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "J. R. R. Tolkien",
                            BookGenre = "Fantasy",
                            Link = "https://www.amazon.co.uk/Hobbit-J-R-Tolkien/dp/0007458428/ref=asc_df_0007458428?tag=bingshoppinga-21&linkCode=df0&hvadid=80882880812450&hvnetw=o&hvqmt=e&hvbmt=be&hvdev=c&hvlocint=&hvlocphy=&hvtargid=pla-4584482456235141&psc=1",
                            PictureUrl = "http://4.bp.blogspot.com/-Q2jfDj24R9Q/UMX-5B1zJ2I/AAAAAAAAAHw/0rOGgxaYtnw/s1600/The+Hobbit.jpg",
                            Price = 6.5499999999999998,
                            Synopsis = "Bilbo Baggins enjoys a quiet and contented life, with no desire to travel far from the comforts of home; then one day the wizard Gandalf and a band of dwarves arrive unexpectedly and enlist his services – as a burglar – on a dangerous expedition to raid the treasure-hoard of Smaug the dragon. Bilbo’s life is never to be the same again.",
                            Title = "The Hobbit"
                        },
                        new
                        {
                            Id = 2,
                            Author = "J. R. R. Tolkien",
                            BookGenre = "Fantasy",
                            Link = "https://www.amazon.co.uk/Lord-Rings-Boxed-Set/dp/0007581149/ref=asc_df_0007581149?tag=bingshoppinga-21&linkCode=df0&hvadid=80608002971184&hvnetw=o&hvqmt=e&hvbmt=be&hvdev=c&hvlocint=&hvlocphy=&hvtargid=pla-4584207578206752&psc=1",
                            PictureUrl = "http://d20eq91zdmkqd.cloudfront.net/assets/images/book/large/9780/0075/9780007581146.jpg",
                            Price = 39.990000000000002,
                            Synopsis = "Sauron, the Dark Lord, has gathered to him all the Rings of Power – the means by which he intends to rule Middle-earth. All he lacks in his plans for dominion is the One Ring – the ring that rules them all – which has fallen into the hands of the hobbit, Bilbo Baggins. In a sleepy village in the Shire, young Frodo Baggins finds himself faced with an immense task, as the Ring is entrusted to his care. He must leave his home and make a perilous journey across the realms of Middle-earth to the Crack of Doom, deep inside the territories of the Dark Lord. There he must destroy the Ring forever and foil the Dark Lord in his evil purpose.",
                            Title = "The Lord of the Rings "
                        },
                        new
                        {
                            Id = 3,
                            Author = "Jane Austen",
                            BookGenre = "Romance",
                            Link = "https://www.amazon.co.uk/Pride-Prejudice-Alma-Classics-Evergreens/dp/1847493696/ref=asc_df_1847493696?tag=bingshoppinga-21&linkCode=df0&hvadid=80401845130311&hvnetw=o&hvqmt=e&hvbmt=be&hvdev=c&hvlocint=&hvlocphy=&hvtargid=pla-4584001419445871&psc=1",
                            PictureUrl = "/images/books/Pride.png",
                            Price = 5.3899999999999997,
                            Synopsis = "The pride of high-ranking Mr Darcy and the prejudice of middle-class Elizabeth Bennet conduct an absorbing dance through the rigid social hierarchies of early-nineteenth-century England, with the passion of the two unlikely lovers growing as their union seems ever more improbable.",
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Leo Tolsoy",
                            BookGenre = "Drama",
                            Link = "https://www.amazon.co.uk/Anna-Karenina-Wordsworth-Classics-Tolstoy/dp/1853262714",
                            PictureUrl = "/images/books/Anna.png",
                            Price = 12.99,
                            Synopsis = "Anna Karenina tells of the doomed love affair between the sensuous and rebellious Anna and the dashing officer, Count Vronsky. Tragedy unfolds as Anna rejects her passionless marriage and must endure the hypocrisies of society. Set against a vast and richly textured canvas of nineteenth-century Russia, the novel's seven major characters create a dynamic imbalance, playing out the contrasts of city and country life and all the variations on love and family happiness. While previous versions have softened the robust, and sometimes shocking, quality of Tolstoy's writing, Pevear and Volokhonsky have produced a translation true to his powerful voice. This award-winning team's authoritative edition also includes an illuminating introduction and explanatory notes. Beautiful, vigorous, and eminently readable, this Anna Karenina will be the definitive text for generations to come.",
                            Title = "Anna Karenina"
                        },
                        new
                        {
                            Id = 5,
                            Author = "George Orwell",
                            BookGenre = "SciFi",
                            Link = "https://www.amazon.co.uk/1984-Nineteen-Eighty-Four-Twentieth-Masterpiece/dp/184697576X/ref=sr_1_1_sspa?crid=3SC3VA96NF93Z&keywords=1984+george+orwell&qid=1638528594&s=books&sprefix=1984%2Cstripbooks%2C164&sr=1-1-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUEzTkRPWkQ4MDNLMlpQJmVuY3J5cHRlZElkPUEwODI1NzI1MVkzWUFEWUhTMVM1TCZlbmNyeXB0ZWRBZElkPUEwNjk5MzU2RFNJSTdLSjlKVUU0JndpZGdldE5hbWU9c3BfYXRmJmFjdGlvbj1jbGlja1JlZGlyZWN0JmRvTm90TG9nQ2xpY2s9dHJ1ZQ==",
                            PictureUrl = "/images/books/1984.png",
                            Price = 5.9900000000000002,
                            Synopsis = "Winston Smith attempts to fights back against a totalitarian Party that rules Oceania and his entire life. It is a dystopian novel that tells the story of Winston Smith and warns of the dangers of a totalitarian government that rules through fear, surveillance, propaganda, and brainwashing.",
                            Title = "1984"
                        },
                        new
                        {
                            Id = 6,
                            Author = "William Shakespeare",
                            BookGenre = "Tragedy",
                            Link = "https://www.amazon.co.uk/Hamlet-William-Shakespeare/dp/B09JJJ7234/ref=sr_1_1_sspa?crid=Y8TUQY6FUX5R&keywords=hamlet+book&qid=1638529096&s=books&sprefix=hamlet%2Cstripbooks%2C172&sr=1-1-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUFQSFNPUlJZNURZOE8mZW5jcnlwdGVkSWQ9QTAwMzY3NDU3ODk4SFAxRENNUDEmZW5jcnlwdGVkQWRJZD1BMDMyNjk2MklETVBCTUxCMzZSVyZ3aWRnZXROYW1lPXNwX2F0ZiZhY3Rpb249Y2xpY2tSZWRpcmVjdCZkb05vdExvZ0NsaWNrPXRydWU=",
                            PictureUrl = "/images/books/Hamlet.png",
                            Price = 7.9900000000000002,
                            Synopsis = "Prince Hamlet is depressed. Having been summoned home to Denmark from school in Germany to attend his father's funeral, he is shocked to find his mother Gertrude already remarried. The Queen has wed Hamlet's Uncle Claudius, the dead king's brother.",
                            Title = "Hamlet"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Albert Camus",
                            BookGenre = "Philosophical",
                            Link = "https://www.amazon.co.uk/Stranger-Albert-Camus-Paperback/dp/B01181UBSU/ref=sr_1_3?crid=6SCM9M2XABXI&keywords=the+stranger+book+albert+camus&qid=1638529430&sprefix=the+stranger+book%2Cstripbooks%2C167&sr=8-3",
                            PictureUrl = "/images/books/Stranger.png",
                            Price = 20.32,
                            Synopsis = "The Stranger tells the strange and baffling story of a young shipping clerk, Meursault, and the surprising ways he reacts to the world around him.",
                            Title = "The Stranger"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Franz Kafka",
                            BookGenre = "Fiction",
                            Link = "https://www.amazon.co.uk/Trial-Legend-Classics-Franz-Kafka/dp/1789559529/ref=sr_1_2_sspa?keywords=the+trial&qid=1638529616&sr=8-2-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUExTFpIOVdCQlpHS0c2JmVuY3J5cHRlZElkPUEwNjA2MjIwRDhYQklHU0xaNldDJmVuY3J5cHRlZEFkSWQ9QTA1MTM5MTQxUzMyNkIxRFo2RDBFJndpZGdldE5hbWU9c3BfYXRmJmFjdGlvbj1jbGlja1JlZGlyZWN0JmRvTm90TG9nQ2xpY2s9dHJ1ZQ==",
                            PictureUrl = "/images/books/Trial.png",
                            Price = 7.79,
                            Synopsis = "The Trial is the chronicle of that intervening year of K.'s case, his struggles and encounters with the invisible Law and the untouchable Court. It is an account, ultimately, of state-induced self-destruction. Yet, as in all of Kafka's best writing, the 'meaning' is far from clear.",
                            Title = "The Trial"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Ralph Ellison",
                            BookGenre = "Fiction",
                            Link = "https://www.amazon.co.uk/Invisible-Man-Penguin-Modern-Classics/dp/0141184426/ref=sr_1_1?crid=3GBXQS9JTZZ2Q&keywords=invisible+man+ralph+ellison&qid=1638529783&sprefix=invisible+man%2Caps%2C189&sr=8-1",
                            PictureUrl = "/images/books/Invisible.png",
                            Price = 6.9900000000000002,
                            Synopsis = "Invisible Man is the story of a young black man from the South who does not fully understand racism in the world. Filled with hope about his future, he goes to college, but gets expelled for showing one of the white benefactors the real and seamy side of black existence.",
                            Title = "Invisible Man"
                        },
                        new
                        {
                            Id = 10,
                            Author = "Salman Rushdie",
                            BookGenre = "MagicRealism",
                            Link = "https://www.amazon.co.uk/Midnights-Children-Vintage-Classics-Rushdie/dp/0099511894/ref=sr_1_1?crid=2BA0EOIER0WQP&keywords=midnight+children+by+salman+rushdie&qid=1638530052&sprefix=midnight+ch%2Caps%2C170&sr=8-1",
                            PictureUrl = "/images/books/Midnight.png",
                            Price = 8.1899999999999995,
                            Synopsis = "Midnight children covers the experiences of three generations of a Sinai family living in Srinagar Amritsar and Agra and then in Bombay and finally migrating to Karachi. Saleem Sinai is the narrator of the events. He works in a pickle factory by day and records his experiences by night.",
                            Title = "Midnights Children"
                        },
                        new
                        {
                            Id = 11,
                            Author = "Nikolai Gogol",
                            BookGenre = "Fiction",
                            Link = "https://www.amazon.co.uk/Dead-Souls-Nikolai-Gogol/dp/B084DGQKDS/ref=sr_1_1_sspa?keywords=Dead+Souls&qid=1638530381&sr=8-1-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUFKMVBQRzk3NU9MRk0mZW5jcnlwdGVkSWQ9QTA5OTU2MTZTNDgxSFBQNFhNVEgmZW5jcnlwdGVkQWRJZD1BMDgwMjgxMjFRMDI3MUdYUVhHUTAmd2lkZ2V0TmFtZT1zcF9hdGYmYWN0aW9uPWNsaWNrUmVkaXJlY3QmZG9Ob3RMb2dDbGljaz10cnVl",
                            PictureUrl = "/images/books/Deadsouls.png",
                            Price = 10.99,
                            Synopsis = "Dead Souls Summary Dead Souls, by Nikolai Gogol, is a satirical examination of 1800's Russian nobility and society. The work is often called Gogol's greatest. It is also considered a Russian prose poem. In post-Napoleonic Russia, landowners owned serfs who worked the land.",
                            Title = "Dead Souls"
                        },
                        new
                        {
                            Id = 12,
                            Author = "James Joyce",
                            BookGenre = "Modernist",
                            Link = "https://www.amazon.co.uk/James-Joyce-Ulysses-Penguin-Classics/dp/B00I611LBM/ref=sr_1_1?crid=6VV1MUKPR88A&keywords=ulysses+james+joyce+penguin&qid=1638530666&s=books&sprefix=ulysses+james+joyce+pen%2Cstripbooks%2C150&sr=1-1",
                            PictureUrl = "/images/books/Ulysses.png",
                            Price = 12.69,
                            Synopsis = "Ulysses follows Leopold Bloom as he goes from place to place in Dublin over the course of June 16, 1904, from 8 a.m. until 3 a.m. Joyce chose that particular day because it wasthe day of his first date with his wife, Nora Barnacle.",
                            Title = "Ulysses"
                        },
                        new
                        {
                            Id = 13,
                            Author = "Stephen King",
                            BookGenre = "Fiction",
                            Link = "https://www.amazon.co.uk/Rita-Hayworth-and-Shawshank-Redemption/dp/1982155752/ref=sr_1_5?keywords=Shawshank+Redemption+book&qid=1638545684&sr=8-5",
                            PictureUrl = "/images/books/Rita Hayworth and Shawshank Redemption.jpg",
                            Price = 9.7799999999999994,
                            Synopsis = "1 New York Times bestselling author Stephen King’s beloved novella, Rita Hayworth and Shawshank Redemption—the basis for the Best Picture Academy Award–nominee The Shawshank Redemption—about an unjustly imprisoned convict who seeks a strangely satisfying revenge, is now available for the first time as a standalone book.A mesmerizing tale of unjust imprisonment and offbeat escape, Rita Hayworth and Shawshank Redemption is one of Stephen King’s most beloved and iconic stories, and it helped make Castle Rock a place readers would * to over and over again.",
                            Title = "Rita Hayworth and Shawshank Redemption"
                        },
                        new
                        {
                            Id = 14,
                            Author = "Nicholas Sparks",
                            BookGenre = "Romance",
                            Link = "https://www.amazon.co.uk/Notebook-Sparks-Nicholas-Paperback/dp/B00IIB02QK/ref=sr_1_3?crid=31BQIM5HJB63N&keywords=the+notebook+nicholas+sparks&qid=1638546490&s=books&sprefix=the+notebook+ni%2Cstripbooks%2C188&sr=1-3",
                            PictureUrl = "/images/books/The_Notebook.jpg",
                            Price = 6.6900000000000004,
                            Synopsis = "The Notebook is the love story to end all love stories - it will break your heart, heal it back up and break it all over again.",
                            Title = "The Notebook"
                        },
                        new
                        {
                            Id = 15,
                            Author = "John Steinbeck",
                            BookGenre = "Tragedy",
                            Link = "https://www.amazon.co.uk/Mice-Men-Penguin-Red-Classics/dp/0141023570/ref=sr_1_1?keywords=Of+Mice+and+Men+by+John+Steinbeck&qid=1638546894&s=books&sr=1-1",
                            PictureUrl = "/images/books/Of Mice and Men.jpg",
                            Price = 6.9900000000000002,
                            Synopsis = "Drifters in search of work, George and his childlike friend Lennie, have nothing in the world except the clothes on their back - and a dream that one day they will have some land of their own. Eventually they find work on a ranch in California's Salinas Valley, but their hopes are dashed as Lennie - struggling against extreme cruelty, misunderstanding and feelings of jealousy - becomes a victim of his own strength. Tackling universal themes of friendship and shared vision, and giving a voice to America's lonely and dispossessed, Of Mice and Men remains Steinbeck's most popular work, achieving success as a novel, Broadway play and three acclaimed films.",
                            Title = "Of Mice and Men"
                        },
                        new
                        {
                            Id = 16,
                            Author = "George R.R. Martin",
                            BookGenre = "Fantasy",
                            Link = "https://www.amazon.co.uk/Fire-Blood-Thrones-Targaryen-History/dp/0008402787/ref=pd_sbs_1/262-6485344-6957429?pd_rd_w=XJWhm&pf_rd_p=c90ec214-58e5-4089-9469-cee2bb7b5d96&pf_rd_r=JCC1960WCAT3HHMP9Q0E&pd_rd_r=1c39f0f3-c3dd-4b88-ba9c-9eb848a741d4&pd_rd_wg=WTZVp&pd_rd_i=0008402787&psc=1",
                            PictureUrl = "/images/books/Fire and blood.jpg",
                            Price = 5.9900000000000002,
                            Synopsis = "Centuries before A Game of Thrones, an even greater game began, one that set the skies alight with dragon flame and saw the Seven Kingdoms turned to ash. So began the Targaryens’ bloody rule, with fire and blood. Setting brother against brother, mother against daughter, and dragon against dragon. Chronicled by a learned maester of the Citadel, this thrilling and bloody history of Westeros tells the story of where the battle for the Iron Throne began…",
                            Title = "Fire and Blood"
                        },
                        new
                        {
                            Id = 17,
                            Author = "Plato",
                            BookGenre = "Philosophical",
                            Link = "https://www.amazon.co.uk/Republic-Penguin-Classics-Plato/dp/0140455116/ref=sr_1_3?crid=2WSL8U42WFLDJ&keywords=plato+republic&qid=1638547554&s=books&sprefix=plato+%2Cstripbooks%2C502&sr=1-3",
                            PictureUrl = "/images/books/The Republic.jpg",
                            Price = 7.1900000000000004,
                            Synopsis = "Plato's Republic is widely acknowledged as one of the most influential works in the history of philosophy. Presented in the form of a dialogue between Socrates and three different interlocutors, it is an inquiry into the notion of a perfect community and the ideal individual within it. During the conversation other questions are raised: what is goodness; what is reality; what is knowledge; what is the purpose of education? With remarkable lucidity and deft use of allegory, Plato arrives at a depiction of a state bound by harmony and ruled by 'philosopher kings'.",
                            Title = "The Republic"
                        },
                        new
                        {
                            Id = 18,
                            Author = "Richard Osman",
                            BookGenre = "Fiction",
                            Link = "https://www.amazon.co.uk/s?k=the+man+who+died+twice+richard+osman&i=stripbooks&crid=3Q844228FAPDJ&sprefix=The+men+who+di%2Cstripbooks%2C176&ref=nb_sb_ss_sc_1_14",
                            PictureUrl = "/images/books/The man who dies twice.jpg",
                            Price = 9.0,
                            Synopsis = "Elizabeth has received a letter from an old colleague, a man with whom she has a long history. He's made a big mistake, and he needs her help. His story involves stolen diamonds, a violent mobster, and a very real threat to his life.As bodies start piling up, Elizabeth enlists Joyce, Ibrahim and Ron in the hunt for a ruthless murderer. And if they find the diamonds too? Well, wouldn't that be a bonus?But this time they are up against an enemy who wouldn't bat an eyelid at knocking off four septuagenarians. Can the Thursday Murder Club find the killer (and the diamonds) before the killer finds them?",
                            Title = "The Man Who Died Twice "
                        },
                        new
                        {
                            Id = 19,
                            Author = "Suzanne Collins",
                            BookGenre = "Fiction",
                            Link = "https://www.amazon.co.uk/Hunger-Games-Trilogy-Suzanne-Collins/dp/1407135449/ref=sr_1_11?keywords=hunger+games+book+1&qid=1638371618&sr=8-11",
                            PictureUrl = "/images/books/The-Hunger-Games.jpg",
                            Price = 17.09,
                            Synopsis = "In the ruins of a place once known as North America lies the nation of Panem, a shining Capitol surrounded by twelve outlying districts. The Capitol is harsh and cruel and keeps the districts in line by forcing them all to send one boy and one girl between the ages of twelve and eighteen to participate in the annual Hunger Games, a fight to the death on live TV.Sixteen-year-old Katniss Everdeen, who lives alone with her mother and younger sister, regards it as a death sentence when she steps forward to take her sister's place in the Games. But Katniss has been close to dead before—and survival, for her, is second nature. Without really meaning to, she becomes a contender. But if she is to win, she will have to start making choices that weight survival against humanity and life against love.",
                            Title = "The Hunger Games"
                        },
                        new
                        {
                            Id = 20,
                            Author = "John Steinbeck",
                            BookGenre = "Fiction",
                            Link = "https://www.amazon.co.uk/East-Eden-John-Steinbeck/dp/0670287385",
                            PictureUrl = "https://bookaudio.online/uploads/images/media/184/jT_yinMH8Xl8UiU3-john-steinbeck-east-of-eden.jpg",
                            Price = 61.640000000000001,
                            Synopsis = "In the ruins of a place once known as North America lies the nation of Panem, a shining Capitol surrounded by twelve outlying districts. The Capitol is harsh and cruel and keeps the districts in line by forcing them all to send one boy and one girl between the ages of twelve and eighteen to participate in the annual Hunger Games, a fight to the death on live TV.Sixteen-year-old Katniss Everdeen, who lives alone with her mother and younger sister, regards it as a death sentence when she steps forward to take her sister's place in the Games. But Katniss has been close to dead before—and survival, for her, is second nature. Without really meaning to, she becomes a contender. But if she is to win, she will have to start making choices that weight survival against humanity and life against love.",
                            Title = "East of Eden"
                        });
                });

            modelBuilder.Entity("YJKBooks.Entities.BookListItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("FavouriteBookListId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("BookId");

                    b.HasIndex("FavouriteBookListId");

                    b.ToTable("BookListItem");
                });

            modelBuilder.Entity("YJKBooks.Entities.FavouriteBookList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FavouriteBookList");
                });

            modelBuilder.Entity("YJKBooks.Entities.Reviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("YJKBooks.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("YJKBooks.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("YJKBooks.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YJKBooks.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("YJKBooks.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YJKBooks.Entities.BookListItem", b =>
                {
                    b.HasOne("YJKBooks.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YJKBooks.Entities.FavouriteBookList", "FavouriteBookList")
                        .WithMany("Items")
                        .HasForeignKey("FavouriteBookListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("FavouriteBookList");
                });

            modelBuilder.Entity("YJKBooks.Entities.Reviews", b =>
                {
                    b.HasOne("YJKBooks.Entities.Book", "Book")
                        .WithMany("BookReviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("YJKBooks.Entities.Book", b =>
                {
                    b.Navigation("BookReviews");
                });

            modelBuilder.Entity("YJKBooks.Entities.FavouriteBookList", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
