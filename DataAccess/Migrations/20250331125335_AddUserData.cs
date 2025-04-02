using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "dbo",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "PurchaseDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 3, 31, 15, 53, 34, 526, DateTimeKind.Local).AddTicks(487), new DateTime(2025, 3, 31, 15, 53, 34, 526, DateTimeKind.Local).AddTicks(580) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "PurchaseDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 3, 31, 15, 53, 34, 526, DateTimeKind.Local).AddTicks(663), new DateTime(2025, 3, 31, 15, 53, 34, 526, DateTimeKind.Local).AddTicks(664) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "UserId", "Email", "FullName", "Password", "Role", "Username" },
                values: new object[] { 1, "tufar220@gmail.com", "Ömer Faruk", "admin", "Admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "PurchaseDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 1, 1, 16, 30, 17, 594, DateTimeKind.Local).AddTicks(1169), new DateTime(2025, 1, 1, 16, 30, 17, 594, DateTimeKind.Local).AddTicks(1881) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "PurchaseDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 1, 1, 16, 30, 17, 594, DateTimeKind.Local).AddTicks(1998), new DateTime(2025, 1, 1, 16, 30, 17, 594, DateTimeKind.Local).AddTicks(1999) });
        }
    }
}
