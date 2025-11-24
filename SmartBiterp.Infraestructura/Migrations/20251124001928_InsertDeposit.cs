using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartBiterp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertDeposit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "Id", "Amount", "CreatedAt", "Date", "MoneyFundId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 150.00m, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 2, 80.00m, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 3, 200.00m, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
