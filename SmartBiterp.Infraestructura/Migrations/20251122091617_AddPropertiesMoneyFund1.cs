using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartBiterp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertiesMoneyFund1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_MoneyFunds_MoneyFundId",
                table: "Deposits");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseHeaders_MoneyFunds_MoneyFundId",
                table: "ExpenseHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "FundType",
                table: "MoneyFunds",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "MoneyFunds",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_MoneyFunds_MoneyFundId",
                table: "Deposits",
                column: "MoneyFundId",
                principalTable: "MoneyFunds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseHeaders_MoneyFunds_MoneyFundId",
                table: "ExpenseHeaders",
                column: "MoneyFundId",
                principalTable: "MoneyFunds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_MoneyFunds_MoneyFundId",
                table: "Deposits");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseHeaders_MoneyFunds_MoneyFundId",
                table: "ExpenseHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "FundType",
                table: "MoneyFunds",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "MoneyFunds",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_MoneyFunds_MoneyFundId",
                table: "Deposits",
                column: "MoneyFundId",
                principalTable: "MoneyFunds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseHeaders_MoneyFunds_MoneyFundId",
                table: "ExpenseHeaders",
                column: "MoneyFundId",
                principalTable: "MoneyFunds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
