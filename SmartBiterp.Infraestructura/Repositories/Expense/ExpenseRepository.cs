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

        public async Task AddExpenseAsync(ExpenseHeader header, IEnumerable<ExpenseDetail> details)
        {
            using var trx = await _context.Database.BeginTransactionAsync();

            try
            {
                await _context.ExpenseHeaders.AddAsync(header);

                foreach (var d in details)
                    await _context.ExpenseDetails.AddAsync(d);

                await _context.SaveChangesAsync();
                await trx.CommitAsync();
            }
            catch
            {
                await trx.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<ExpenseHeader>> GetExpensesByDateRangeAsync(DateTime start, DateTime end)
        {
            return await _context.ExpenseHeaders
                .Include(e => e.Details)
                .Where(e => e.Date >= start && e.Date <= end)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalByTypeAsync(int expenseTypeId, int month, int year)
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
