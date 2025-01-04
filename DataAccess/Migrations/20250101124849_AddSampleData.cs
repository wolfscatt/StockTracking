using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Category 1" },
                    { 2, "Category 2" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ProductName", "PurchaseDate", "UnitPrice", "UnitsInStock", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, "Description 1", "Product 1", new DateTime(2025, 1, 1, 15, 48, 49, 558, DateTimeKind.Local).AddTicks(8660), 10m, (short)100, new DateTime(2025, 1, 1, 15, 48, 49, 560, DateTimeKind.Local).AddTicks(179) },
                    { 2, 2, "Description 2", "Product 2", new DateTime(2025, 1, 1, 15, 48, 49, 560, DateTimeKind.Local).AddTicks(352), 20m, (short)200, new DateTime(2025, 1, 1, 15, 48, 49, 560, DateTimeKind.Local).AddTicks(353) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);
        }
    }
}
