using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartBiterp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertBudget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "Id", "AllocatedAmount", "CreatedAt", "ExpenseTypeId", "Month", "Status", "UpdatedAt", "Year" },
                values: new object[,]
                {
                    { 1, 350.00m, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 1, 2, 1, null, 2025 },
                    { 2, 400.00m, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 1, 3, 1, null, 2025 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
