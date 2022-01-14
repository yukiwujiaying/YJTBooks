using Microsoft.EntityFrameworkCore.Migrations;

namespace YJKBooks.Migrations
{
    public partial class AddTwoUserInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b77450f9-6a13-44d3-bca6-8a5b108615bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e899fb77-d127-417e-8cd6-b7df6aaad80f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c83548e0-6dab-4db5-a22b-3c1cc8b54c70", "e73bcaa5-cb65-49c4-bcb9-0d501ba993e8", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "34740026-e725-4d4a-915f-30d8769d2613", "b74f432d-1ef4-4404-89b6-7d03ec2e99dc", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34740026-e725-4d4a-915f-30d8769d2613");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c83548e0-6dab-4db5-a22b-3c1cc8b54c70");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b77450f9-6a13-44d3-bca6-8a5b108615bd", "4167a08c-6541-4f65-bf2d-a004a9d06293", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e899fb77-d127-417e-8cd6-b7df6aaad80f", "e24510fc-4f8f-4280-a7b3-2dce9c119722", "Admin", "ADMIN" });
        }
    }
}
