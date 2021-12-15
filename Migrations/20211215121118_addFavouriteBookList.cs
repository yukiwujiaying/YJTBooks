using Microsoft.EntityFrameworkCore.Migrations;

namespace YJKBooks.Migrations
{
    public partial class addFavouriteBookList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavouriteBookList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteBookList", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_BookListItem_BookId",
                table: "BookListItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookListItem_FavouriteBookListId",
                table: "BookListItem",
                column: "FavouriteBookListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookListItem");

            migrationBuilder.DropTable(
                name: "FavouriteBookList");
        }
    }
}
