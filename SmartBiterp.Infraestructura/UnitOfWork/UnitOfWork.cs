using SmartBiterp.Domain.Interfaces;
using SmartBiterp.Domain.Interfaces.Expense;
using SmartBiterp.Domain.Interfaces.Security;
using SmartBiterp.Domain.Interfaces.System;
using SmartBiterp.Infrastructure.Persistence.Context;
using SmartBiterp.Infrastructure.Repositories.Expense;
using SmartBiterp.Infrastructure.Repositories.Security;
using SmartBiterp.Infrastructure.Repositories.System;

namespace SmartBiterp.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Budgets = new BudgetRepository(_context);
            Deposits = new DepositRepository(_context);
            Expenses = new ExpenseRepository(_context);
            ExpenseTypes = new ExpenseTypeRepository(_context);
            MoneyFunds = new MoneyFundRepository(_context);

            Users = new UserRepository(_context);
            Roles = new RoleRepository(_context);
            Permissions = new PermissionRepository(_context);
            RolePermissions = new RolePermissionRepository(_context);
            Menus = new MenuRepository(_context);
            MenuRoles = new MenuRoleRepository(_context);

            AuditLogs = new AuditLogRepository(_context);
            Reports = new ReportRepository(_context);
        }

        public IExpenseTypeRepository ExpenseTypes { get; }
        public IMoneyFundRepository MoneyFunds { get; }
        public IBudgetRepository Budgets { get; }
        public IExpenseRepository Expenses { get; }
        public IDepositRepository Deposits { get; }
        public IReportRepository Reports { get; }

        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public IPermissionRepository Permissions { get; }
        public IRolePermissionRepository RolePermissions { get; }
        public IMenuRepository Menus { get; }
        public IMenuRoleRepository MenuRoles { get; }

        public IAuditLogRepository AuditLogs { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}