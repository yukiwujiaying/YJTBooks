using Microsoft.EntityFrameworkCore.Migrations;

namespace YJKBooks.Migrations
{
    public partial class attachReviewToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f88e4b4-0109-47e5-a3ca-9f0868b3d5c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5288a26-7384-4e66-a8c9-1d7f91320b74");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20185b77-0f4e-4a6f-8640-8110eef54df7", "0c862d93-1fb4-4ed7-8b2d-fa6325ac4fac", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c774ac7-fbb7-4284-9c7d-6631e9eab19e", "d02da971-06e6-426d-90f6-7a1bab33eeaa", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20185b77-0f4e-4a6f-8640-8110eef54df7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c774ac7-fbb7-4284-9c7d-6631e9eab19e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5288a26-7384-4e66-a8c9-1d7f91320b74", "9c704745-d192-4429-843b-a8b356294e8f", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f88e4b4-0109-47e5-a3ca-9f0868b3d5c6", "00cd9f68-87ef-4258-959c-f500093246a9", "Admin", "ADMIN" });
        }
    }
}
