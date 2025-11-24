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
        }
    }
}