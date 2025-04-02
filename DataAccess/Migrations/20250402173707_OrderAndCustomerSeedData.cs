using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OrderAndCustomerSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, "İstanbul", "Test@gmail.com", "Ali Veli", "1234567890" },
                    { 2, "Samsun", "Ahmet@gmail.com", "Ahmet Mehmet", "5215738232" },
                    { 3, "Ankara", "fatma06@gmail.com", "Ayşe Fatma", "5168944601" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "PurchaseDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 2, 20, 37, 6, 630, DateTimeKind.Local).AddTicks(5608), new DateTime(2025, 4, 2, 20, 37, 6, 630, DateTimeKind.Local).AddTicks(5717) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "PurchaseDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 2, 20, 37, 6, 630, DateTimeKind.Local).AddTicks(5796), new DateTime(2025, 4, 2, 20, 37, 6, 630, DateTimeKind.Local).AddTicks(5796) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderDate", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100m },
                    { 2, 2, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m },
                    { 3, 3, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 300m }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, (short)1, 100m },
                    { 2, 2, 2, (short)2, 200m },
                    { 3, 3, 30, (short)3, 300m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

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
        }
    }
}
