using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YJKBooks.Migrations
{
    public partial class addPublishDateInReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f73533d-4dbc-441d-8cad-15304d19c43a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9eba37fc-0565-4e4a-ad2b-8c34c379c871");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedDate",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9706b3ac-c14b-4257-b06e-d44293771010", "44fd34c1-2f24-4c19-8e86-cac2163e9808", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1f5d9569-66b3-41c2-9955-03a28a29a05b", "7444ac08-95a9-4301-a313-084e04399c9a", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f5d9569-66b3-41c2-9955-03a28a29a05b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9706b3ac-c14b-4257-b06e-d44293771010");

            migrationBuilder.DropColumn(
                name: "PublishedDate",
                table: "Reviews");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9eba37fc-0565-4e4a-ad2b-8c34c379c871", "0346877f-e2b5-4987-95b6-fb324ff45432", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f73533d-4dbc-441d-8cad-15304d19c43a", "77dde8b0-993c-4718-81ad-b3c7a925220f", "Admin", "ADMIN" });
        }
    }
}
