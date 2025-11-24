using Microsoft.EntityFrameworkCore;

using SmartBiterp.Domain.Entities.Expense;
using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Domain.Entities.System;
using SmartBiterp.Domain.Enums;

namespace SmartBiterp.Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public static readonly DateTime StaticCreatedAt = new DateTime(2025, 7, 28, 0, 0, 0, DateTimeKind.Utc);
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ExpenseType> ExpenseTypes => Set<ExpenseType>();
        public DbSet<MoneyFund> MoneyFunds => Set<MoneyFund>();
        public DbSet<Budget> Budgets => Set<Budget>();
        public DbSet<ExpenseHeader> ExpenseHeaders => Set<ExpenseHeader>();
        public DbSet<ExpenseDetail> ExpenseDetails => Set<ExpenseDetail>();
        public DbSet<Deposit> Deposits => Set<Deposit>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Permission> Permissions => Set<Permission>();
        public DbSet<Menu> Menus => Set<Menu>();
        public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
        public DbSet<MenuRole> MenuRoles => Set<MenuRole>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations from Configurations folder
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
            #region ExpenseType
            modelBuilder.Entity<ExpenseType>().HasData(
                new ExpenseType
                {

                    Id = 1,
                    Code = "ET0001",
                    Description = "Food & Groceries",
                    Category = ExpenseCategoryType.Other,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                }
            );
            #endregion ExpenseType
            #region MoneyFund
            modelBuilder.Entity<MoneyFund>().HasData(
                new MoneyFund
                {
                    Id = 1,
                    Code = "MF0001",
                    Name = "Main Bank Account",
                    FundType = MoneyFundType.BankAccount,
                    InitialBalance = 1000.00m,
                    CurrentBalance = 1000.00m,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new MoneyFund
                {
                    Id = 2,
                    Code = "MF0002",
                    Name = "Office Cash Box",
                    FundType = MoneyFundType.CashBox,
                    InitialBalance = 200.00m,
                    CurrentBalance = 200.00m,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                }
            );
            #endregion MoneyFund
            #region Budget
            modelBuilder.Entity<Budget>().HasData(
                new Budget
                {
                    Id = 1,
                    ExpenseTypeId = 1,
                    Year = 2025,
                    Month = 2,
                    AllocatedAmount = 350.00m,
                    Status = BudgetStatusType.Normal,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new Budget
                {
                    Id = 2,
                    ExpenseTypeId = 1,
                    Year = 2025,
                    Month = 3,
                    AllocatedAmount = 400.00m,
                    Status = BudgetStatusType.Normal,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                }
            );
            #endregion Budget
            #region ExpenseHeader
            modelBuilder.Entity<ExpenseHeader>().HasData(
                new ExpenseHeader
                {
                    Id = 1,
                    Date = new DateTime(2025, 1, 15),
                    MoneyFundId = 1,
                    StoreName = "SuperMarket La Economía",
                    DocumentType = DocumentType.Other,
                    Notes = "Compra mensual",
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new ExpenseHeader
                {
                    Id = 2,
                    Date = new DateTime(2025, 1, 18),
                    MoneyFundId = 1,
                    StoreName = "Papelería Central",
                    DocumentType = DocumentType.Other,
                    Notes = "Útiles escolares",
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                }
            );
            #endregion ExpenseHeader
            #region ExpenseDetail
            modelBuilder.Entity<ExpenseDetail>().HasData(
                new ExpenseDetail
                {
                    Id = 1,
                    ExpenseHeaderId = 1,
                    ExpenseTypeId = 1, // Food
                    Amount = 150.75m,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new ExpenseDetail
                {
                    Id = 2,
                    ExpenseHeaderId = 1,
                    ExpenseTypeId = 2, // Utilities
                    Amount = 80.50m,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new ExpenseDetail
                {
                    Id = 3,
                    ExpenseHeaderId = 2,
                    ExpenseTypeId = 2, // Office Supplies
                    Amount = 45.00m,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                }
            );
            #endregion ExpenseDetail
            #region Deposit
            modelBuilder.Entity<Deposit>().HasData(
                new Deposit
                {
                    Id = 1,
                    Date = new DateTime(2025, 02, 10),
                    MoneyFundId = 1,               // Debe existir en MoneyFunds
                    Amount = 150.00m,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new Deposit
                {
                    Id = 2,
                    Date = new DateTime(2025, 02, 15),
                    MoneyFundId = 1,
                    Amount = 80.00m,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new Deposit
                {
                    Id = 3,
                    Date = new DateTime(2025, 03, 01),
                    MoneyFundId = 3,
                    Amount = 200.00m,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                }
            );
            #endregion Deposit
            #region Menu

            modelBuilder.Entity<Menu>().HasData(
                new Menu
                {
                    Id = 1,
                    Title = "Mantenimientos",
                    Route = "",
                    Icon = "folder",
                    ParentId = null,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new Menu
                {
                    Id = 2,
                    Title = "Tipos de Gasto",
                    Route = "/mantenimientos/expense-types",
                    Icon = "list",
                    ParentId = 1,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new Menu
                {
                    Id = 3,
                    Title = "Fondo Monetario",
                    Route = "/mantenimientos/money-funds",
                    Icon = "wallet",
                    ParentId = 1,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new Menu
                {
                    Id = 4,
                    Title = "Movimientos",
                    Route = "",
                    Icon = "arrows-spin",
                    ParentId = null,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new Menu
                {
                    Id = 5,
                    Title = "Presupuesto por tipo de gasto",
                    Route = "/movimientos/budgets",
                    Icon = "money-check",
                    ParentId = 4,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new Menu
                {
                    Id = 6,
                    Title = "Registros de gastos",
                    Route = "/movimientos/expenses",
                    Icon = "file-invoice-dollar",
                    ParentId = 4,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new Menu
                {
                    Id = 7,
                    Title = "Depósitos",
                    Route = "/movimientos/deposits",
                    Icon = "money-bill-transfer",
                    ParentId = 4,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new Menu
                {
                    Id = 8,
                    Title = "Consultas y Reportes",
                    Route = "",
                    Icon = "chart-bar",
                    ParentId = null,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new Menu
                {
                    Id = 9,
                    Title = "Consulta de movimientos",
                    Route = "/reportes/movement-query",
                    Icon = "magnifying-glass-chart",
                    ParentId = 8,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new Menu
                {
                    Id = 10,
                    Title = "Gráfico Comparativo de Presupuesto y Ejecución",
                    Route = "/reportes/budget-vs-execution",
                    Icon = "chart-line",
                    ParentId = 8,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                }
            );
            #endregion
            #region Role
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    RoleType = RoleType.Administrator,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new Role
                {
                    Id = 2,
                    RoleType = RoleType.Manager,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new Role
                {
                    Id = 3,
                    RoleType = RoleType.Accountant,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new Role
                {
                    Id = 4,
                    RoleType = RoleType.Operator,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                },
                new Role
                {
                    Id = 5,
                    RoleType = RoleType.Viewer,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                }
            );
            #endregion
            #region Permission
            modelBuilder.Entity<Permission>().HasData(
                new Permission
                {
                    Id = 1,
                    Code = "VIEW_EXPENSE_TYPES",
                    Description = "Allows viewing of expense types",
                    CreatedAt = StaticCreatedAt
                },
                new Permission
                {
                    Id = 2,
                    Code = "MANAGE_EXPENSE_TYPES",
                    Description = "Allows creating, updating and deleting expense types",
                    CreatedAt = StaticCreatedAt
                },

                new Permission
                {
                    Id = 3,
                    Code = "VIEW_MONEY_FUNDS",
                    Description = "Allows viewing of money funds",
                    CreatedAt = StaticCreatedAt
                },
                new Permission
                {
                    Id = 4,
                    Code = "MANAGE_MONEY_FUNDS",
                    Description = "Allows creating, updating and deleting money funds",
                    CreatedAt = StaticCreatedAt
                },
                new Permission
                {
                    Id = 5,
                    Code = "VIEW_BUDGETS",
                    Description = "Allows viewing of budgets by expense type",
                    CreatedAt = StaticCreatedAt
                },
                new Permission
                {
                    Id = 6,
                    Code = "MANAGE_BUDGETS",
                    Description = "Allows creating, updating and deleting budgets",
                    CreatedAt = StaticCreatedAt
                },

                new Permission
                {
                    Id = 7,
                    Code = "VIEW_EXPENSES",
                    Description = "Allows viewing of expense records",
                    CreatedAt = StaticCreatedAt
                },
                new Permission
                {
                    Id = 8,
                    Code = "MANAGE_EXPENSES",
                    Description = "Allows creating, updating and deleting expenses",
                    CreatedAt = StaticCreatedAt
                },

                new Permission
                {
                    Id = 9,
                    Code = "VIEW_DEPOSITS",
                    Description = "Allows viewing of deposit records",
                    CreatedAt = StaticCreatedAt
                },
                new Permission
                {
                    Id = 10,
                    Code = "MANAGE_DEPOSITS",
                    Description = "Allows creating, updating and deleting deposits",
                    CreatedAt = StaticCreatedAt
                },
                new Permission
                {
                    Id = 11,
                    Code = "VIEW_MOVEMENT_REPORT",
                    Description = "Allows consulting movement reports",
                    CreatedAt = StaticCreatedAt
                },

                new Permission
                {
                    Id = 12,
                    Code = "VIEW_BUDGET_EXECUTION_CHART",
                    Description = "Allows viewing the budget vs execution comparative chart",
                    CreatedAt = StaticCreatedAt
                }
            );
            #endregion
            #region User
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@system.com",
                    RoleId = 1,
                    CreatedAt = StaticCreatedAt,
                    UpdatedAt = null
                }
            );
            #endregion
            #region MenuRole
            modelBuilder.Entity<MenuRole>().HasData(
                new MenuRole { Id = 1, MenuId = 1, RoleId = 1, CreatedAt = StaticCreatedAt },
                new MenuRole { Id = 2, MenuId = 2, RoleId = 1, CreatedAt = StaticCreatedAt },
                new MenuRole { Id = 3, MenuId = 3, RoleId = 1, CreatedAt = StaticCreatedAt },
                new MenuRole { Id = 4, MenuId = 4, RoleId = 1, CreatedAt = StaticCreatedAt },
                new MenuRole { Id = 5, MenuId = 5, RoleId = 1, CreatedAt = StaticCreatedAt }
            );
            #endregion
            #region RolePermission
            modelBuilder.Entity<RolePermission>().HasData(
                new RolePermission
                {
                    Id = 1,
                    RoleId = 1,
                    PermissionId = 1,
                    AssignedAt = StaticCreatedAt,
                    AssignedBy = "system",
                    CreatedAt = StaticCreatedAt
                },
                new RolePermission
                {
                    Id = 2,
                    RoleId = 1,
                    PermissionId = 2,
                    AssignedAt = StaticCreatedAt,
                    AssignedBy = "system",
                    CreatedAt = StaticCreatedAt
                },
                new RolePermission
                {
                    Id = 3,
                    RoleId = 1,
                    PermissionId = 3,
                    AssignedAt = StaticCreatedAt,
                    AssignedBy = "system",
                    CreatedAt = StaticCreatedAt
                },
                new RolePermission
                {
                    Id = 4,
                    RoleId = 1,
                    PermissionId = 4,
                    AssignedAt = StaticCreatedAt,
                    AssignedBy = "system",
                    CreatedAt = StaticCreatedAt
                },
                new RolePermission
                {
                    Id = 5,
                    RoleId = 1,
                    PermissionId = 5,
                    AssignedAt = StaticCreatedAt,
                    AssignedBy = "system",
                    CreatedAt = StaticCreatedAt
                }
            );
            #endregion
        }
    }
}