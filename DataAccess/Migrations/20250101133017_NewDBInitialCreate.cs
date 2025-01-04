using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewDBInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "PurchaseDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 1, 1, 15, 48, 49, 558, DateTimeKind.Local).AddTicks(8660), new DateTime(2025, 1, 1, 15, 48, 49, 560, DateTimeKind.Local).AddTicks(179) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "PurchaseDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 1, 1, 15, 48, 49, 560, DateTimeKind.Local).AddTicks(352), new DateTime(2025, 1, 1, 15, 48, 49, 560, DateTimeKind.Local).AddTicks(353) });
        }
    }
}
