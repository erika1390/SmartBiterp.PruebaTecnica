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

        public async Task<bool> ExistsAsync(int expenseTypeId, int year, int month)
        {
            return await _context.Budgets.AnyAsync(b =>
                b.ExpenseTypeId == expenseTypeId &&
                b.Year == year &&
                b.Month == month
            );
        }

        public async Task<Budget?> GetByIdAsync(int id)
        {
            return await _context.Budgets
                .Include(b => b.ExpenseType)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Budget>> GetByMonthAsync(int year, int month)
        {
            return await _context.Budgets
                .Where(b => b.Year == year && b.Month == month)
                .Include(b => b.ExpenseType)
                .OrderBy(b => b.ExpenseType.Description)
                .ToListAsync();
        }

        public void Remove(Budget entity)
        {
            _context.Budgets.Remove(entity);
        }
    }
}
