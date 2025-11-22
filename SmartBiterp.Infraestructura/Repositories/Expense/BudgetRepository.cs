using Microsoft.EntityFrameworkCore;

using SmartBiterp.Domain.Entities.Expense;
using SmartBiterp.Domain.Interfaces.Expense;
using SmartBiterp.Infrastructure.Persistence.Context;

namespace SmartBiterp.Infrastructure.Repositories.Expense
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly AppDbContext _context;

        public BudgetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Budget entity)
        {
            bool exists = await _context.Budgets
                .AnyAsync(b =>
                    b.ExpenseTypeId == entity.ExpenseTypeId &&
                    b.Month == entity.Month &&
                    b.Year == entity.Year
                );

            if (exists)
                throw new InvalidOperationException("A budget already exists for this type, month and year.");

            await _context.Budgets.AddAsync(entity);
        }

        public async Task<Budget?> GetBudgetAsync(int expenseTypeId, int month, int year)
        {
            return await _context.Budgets
                .FirstOrDefaultAsync(b =>
                    b.ExpenseTypeId == expenseTypeId &&
                    b.Month == month &&
                    b.Year == year);
        }

        public async Task<decimal> GetExecutedAmountAsync(int expenseTypeId, int month, int year)
        {
            var start = new DateTime(year, month, 1);
            var end = start.AddMonths(1).AddDays(-1);

            return await _context.ExpenseDetails
                .Where(d => d.ExpenseTypeId == expenseTypeId &&
                            d.ExpenseHeader.Date >= start &&
                            d.ExpenseHeader.Date <= end)
                .SumAsync(d => d.Amount);
        }
    }
}
