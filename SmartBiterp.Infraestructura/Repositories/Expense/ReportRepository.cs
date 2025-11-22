using Microsoft.EntityFrameworkCore;

using SmartBiterp.Domain.Interfaces.Expense;
using SmartBiterp.Infrastructure.Persistence.Context;

namespace SmartBiterp.Infrastructure.Repositories.Expense
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _context;

        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetBudgetVsExecutionAsync(DateTime start, DateTime end)
        {
            return await _context.ExpenseTypes
                .Select(type => new
                {
                    Type = type.Description,

                    Budget = _context.Budgets
                        .Where(b => b.ExpenseTypeId == type.Id)
                        .Sum(b => b.AllocatedAmount),

                    Execution = _context.ExpenseDetails
                        .Where(d => d.ExpenseTypeId == type.Id &&
                                    d.ExpenseHeader.Date >= start &&
                                    d.ExpenseHeader.Date <= end)
                        .Sum(d => d.Amount)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<object>> GetMovementsAsync(DateTime start, DateTime end)
        {
            var expenses = _context.ExpenseHeaders
                .Where(e => e.Date >= start && e.Date <= end)
                .Select(e => new
                {
                    Type = "Expense",
                    e.Date,
                    e.StoreName,
                    Amount = e.Details.Sum(d => d.Amount)
                });

            var deposits = _context.Deposits
                .Where(d => d.Date >= start && d.Date <= end)
                .Select(d => new
                {
                    Type = "Deposit",
                    d.Date,
                    StoreName = "",
                    d.Amount
                });

            return await expenses.Concat(deposits).ToListAsync();
        }
    }
}
