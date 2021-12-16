using Microsoft.EntityFrameworkCore.Migrations;

namespace YJKBooks.Migrations
{
    public partial class addFavouriteBookListdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_UsersId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_UsersId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "FavouriteBookList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteBookList_UsersId",
                table: "FavouriteBookList",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteBookList_Users_UsersId",
                table: "FavouriteBookList",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteBookList_Users_UsersId",
                table: "FavouriteBookList");

            migrationBuilder.DropIndex(
                name: "IX_FavouriteBookList_UsersId",
                table: "FavouriteBookList");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "FavouriteBookList");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_UsersId",
                table: "Books",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_UsersId",
                table: "Books",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
