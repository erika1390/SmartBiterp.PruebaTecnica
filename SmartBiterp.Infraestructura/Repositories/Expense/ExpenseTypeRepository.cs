using Microsoft.EntityFrameworkCore;

using SmartBiterp.Domain.Entities.Expense;
using SmartBiterp.Domain.Interfaces.Expense;
using SmartBiterp.Infrastructure.Persistence.Context;

namespace SmartBiterp.Infrastructure.Repositories.Expense
{
    public class ExpenseTypeRepository : IExpenseTypeRepository
    {
        private readonly AppDbContext _context;

        public ExpenseTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExpenseType>> GetAllAsync()
            => await _context.ExpenseTypes.ToListAsync();

        public async Task<ExpenseType?> GetByIdAsync(int id)
            => await _context.ExpenseTypes.FindAsync(id);

        public async Task AddAsync(ExpenseType entity)
            => await _context.ExpenseTypes.AddAsync(entity);

        public async Task<string> GetNextCodeAsync()
        {
            int count = await _context.ExpenseTypes.CountAsync();
            return $"EX{(count + 1).ToString("0000")}";
        }
    }
}
