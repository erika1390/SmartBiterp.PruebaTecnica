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

        }
    }
}