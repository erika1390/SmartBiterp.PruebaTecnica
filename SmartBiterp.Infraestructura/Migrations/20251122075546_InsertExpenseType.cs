using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartBiterp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertExpenseType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "Category", "Code", "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { 1, 8, "ET001", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Food & Groceries", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
