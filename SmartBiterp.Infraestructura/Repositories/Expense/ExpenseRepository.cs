using Microsoft.EntityFrameworkCore;

using SmartBiterp.Domain.Entities.Expense;
using SmartBiterp.Domain.Interfaces.Expense;
using SmartBiterp.Infrastructure.Persistence.Context;

namespace SmartBiterp.Infrastructure.Repositories.Expense
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _context;

        public ExpenseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddHeaderAsync(ExpenseHeader header)
        {
            await _context.ExpenseHeaders.AddAsync(header);
        }

        public async Task AddDetailAsync(ExpenseDetail detail)
        {
            await _context.ExpenseDetails.AddAsync(detail);
        }

        public async Task<ExpenseHeader?> GetByIdAsync(int id)
        {
            return await _context.ExpenseHeaders
                .Include(h => h.Details)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<ExpenseHeader>> GetExpensesByDateRangeAsync(DateTime start, DateTime end)
        {
            return await _context.ExpenseHeaders
                .Include(e => e.Details)
                .Where(e => e.Date >= start && e.Date <= end)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalSpentAsync(int year, int month, int expenseTypeId)
        {
            var start = new DateTime(year, month, 1);
            var end = start.AddMonths(1).AddDays(-1);

            return await _context.ExpenseDetails
                .Where(d =>
                    d.ExpenseTypeId == expenseTypeId &&
                    d.ExpenseHeader.Date >= start &&
                    d.ExpenseHeader.Date <= end
                )
                .SumAsync(d => d.Amount);
        }

        public void RemoveHeader(ExpenseHeader header)
        {
            _context.ExpenseHeaders.Remove(header);
        }

        public void RemoveDetail(ExpenseDetail detail)
        {
            _context.ExpenseDetails.Remove(detail);
        }
    }
}