using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartBiterp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertModuloAdminsirtacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedAt", "Icon", "ParentId", "Route", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "folder", null, "", "Mantenimientos", null },
                    { 4, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "arrows-spin", null, "", "Movimientos", null },
                    { 8, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "chart-bar", null, "", "Consultas y Reportes", null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code", "CreatedAt", "Description", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "VIEW_EXPENSE_TYPES", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Allows viewing of expense types", null },
                    { 2, "MANAGE_EXPENSE_TYPES", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Allows creating, updating and deleting expense types", null },
                    { 3, "VIEW_MONEY_FUNDS", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Allows viewing of money funds", null },
                    { 4, "MANAGE_MONEY_FUNDS", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Allows creating, updating and deleting money funds", null },
                    { 5, "VIEW_BUDGETS", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Allows viewing of budgets by expense type", null },
                    { 6, "MANAGE_BUDGETS", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Allows creating, updating and deleting budgets", null },
                    { 7, "VIEW_EXPENSES", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Allows viewing of expense records", null },
                    { 8, "MANAGE_EXPENSES", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Allows creating, updating and deleting expenses", null },
                    { 9, "VIEW_DEPOSITS", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Allows viewing of deposit records", null },
                    { 10, "MANAGE_DEPOSITS", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Allows creating, updating and deleting deposits", null },
                    { 11, "VIEW_MOVEMENT_REPORT", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Allows consulting movement reports", null },
                    { 12, "VIEW_BUDGET_EXECUTION_CHART", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Allows viewing the budget vs execution comparative chart", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "RoleType", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Administrator", null },
                    { 2, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Manager", null },
                    { 3, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Accountant", null },
                    { 4, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Operator", null },
                    { 5, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Viewer", null }
                });

            migrationBuilder.InsertData(
                table: "MenuRoles",
                columns: new[] { "Id", "CreatedAt", "MenuId", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, null },
                    { 4, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 4, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedAt", "Icon", "ParentId", "Route", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "list", 1, "/expense-types", "Tipos de Gasto", null },
                    { 3, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "wallet", 1, "/money-funds", "Fondo Monetario", null },
                    { 5, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "money-check", 4, "/budgets", "Presupuesto por tipo de gasto", null },
                    { 6, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "file-invoice-dollar", 4, "/expenses", "Registros de gastos", null },
                    { 7, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "money-bill-transfer", 4, "/deposits", "Depósitos", null },
                    { 9, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "magnifying-glass-chart", 8, "/movements", "Consulta de movimientos", null },
                    { 10, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "chart-line", 8, "/reports/budget-vs-execution", "Gráfico Comparativo de Presupuesto y Ejecución", null }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "CreatedAt", "PermissionId", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "system", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, null },
                    { 2, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "system", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 2, 1, null },
                    { 3, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "system", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 3, 1, null },
                    { 4, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "system", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 4, 1, null },
                    { 5, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "system", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 5, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "RoleId", "UpdatedAt", "Username" },
                values: new object[] { 1, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "admin@system.com", 1, null, "admin" });

            migrationBuilder.InsertData(
                table: "MenuRoles",
                columns: new[] { "Id", "CreatedAt", "MenuId", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 2, 1, null },
                    { 3, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 3, 1, null },
                    { 5, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 5, 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuRoles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuRoles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
