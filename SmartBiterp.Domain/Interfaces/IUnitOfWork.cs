using SmartBiterp.Domain.Interfaces.Expense;
using SmartBiterp.Domain.Interfaces.Security;
using SmartBiterp.Domain.Interfaces.System;

namespace SmartBiterp.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBudgetRepository Budgets { get; }
        IDepositRepository Deposits { get; }
        IExpenseRepository Expenses { get; }
        IExpenseTypeRepository ExpenseTypes { get; }
        IMoneyFundRepository MoneyFunds { get; }

        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IPermissionRepository Permissions { get; }
        IRolePermissionRepository RolePermissions { get; }
        IMenuRepository Menus { get; }
        IMenuRoleRepository MenuRoles { get; }

        IAuditLogRepository AuditLogs { get; }
        IReportRepository Reports { get; }

        Task<int> SaveChangesAsync();
    }
}