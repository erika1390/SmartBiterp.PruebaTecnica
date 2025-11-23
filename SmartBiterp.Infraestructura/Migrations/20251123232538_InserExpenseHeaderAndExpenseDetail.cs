using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartBiterp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InserExpenseHeaderAndExpenseDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StoreName",
                table: "ExpenseHeaders",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "DocumentType",
                table: "ExpenseHeaders",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "ExpenseHeaders",
                columns: new[] { "Id", "CreatedAt", "Date", "DocumentType", "MoneyFundId", "Notes", "StoreName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, "Compra mensual", "SuperMarket La Economía", null },
                    { 2, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, "Útiles escolares", "Papelería Central", null }
                });

            migrationBuilder.InsertData(
                table: "ExpenseDetails",
                columns: new[] { "Id", "Amount", "CreatedAt", "ExpenseHeaderId", "ExpenseTypeId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 150.75m, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, null },
                    { 2, 80.50m, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 1, 2, null },
                    { 3, 45.00m, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 2, 2, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpenseDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExpenseDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExpenseDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExpenseHeaders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExpenseHeaders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "StoreName",
                table: "ExpenseHeaders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentType",
                table: "ExpenseHeaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);
        }
    }
}
