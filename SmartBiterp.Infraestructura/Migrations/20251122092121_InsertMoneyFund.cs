using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartBiterp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertMoneyFund : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: "ET0001");

            migrationBuilder.InsertData(
                table: "MoneyFunds",
                columns: new[] { "Id", "Code", "CreatedAt", "CurrentBalance", "FundType", "InitialBalance", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "MF0001", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 1000.00m, "BankAccount", 1000.00m, "Main Bank Account", null },
                    { 2, "MF0002", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 200.00m, "CashBox", 200.00m, "Office Cash Box", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MoneyFunds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MoneyFunds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: "ET001");
        }
    }
}
