using Microsoft.EntityFrameworkCore;

using SmartBiterp.Domain.Entities.Expense;
using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Domain.Entities.System;

namespace SmartBiterp.Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
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
        }
    }
}