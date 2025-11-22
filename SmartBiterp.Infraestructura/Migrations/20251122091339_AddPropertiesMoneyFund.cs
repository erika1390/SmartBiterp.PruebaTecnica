using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartBiterp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertiesMoneyFund : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MoneyFunds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentBalance",
                table: "MoneyFunds",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InitialBalance",
                table: "MoneyFunds",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "MoneyFunds");

            migrationBuilder.DropColumn(
                name: "CurrentBalance",
                table: "MoneyFunds");

            migrationBuilder.DropColumn(
                name: "InitialBalance",
                table: "MoneyFunds");
        }
    }
}
