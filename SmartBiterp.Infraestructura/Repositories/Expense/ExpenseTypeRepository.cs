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
        {
            return await _context.ExpenseTypes
                .OrderBy(x => x.Description)
                .ToListAsync();
        }

        public async Task<ExpenseType?> GetByIdAsync(int id)
        {
            return await _context.ExpenseTypes.FindAsync(id);
        }

        public async Task AddAsync(ExpenseType entity)
        {
            await _context.ExpenseTypes.AddAsync(entity);
        }

        public async Task<string> GetNextCodeAsync()
        {
            var lastCode = await _context.ExpenseTypes
                .OrderByDescending(x => x.Id)
                .Select(x => x.Code)
                .FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(lastCode))
                return "EX0001";

            var numberPart = lastCode.Substring(2);

            if (int.TryParse(numberPart, out int number))
            {
                number++;
                return $"EX{number:0000}";
            }
            return "EX0001";
        }


        public void Remove(ExpenseType entity)
        {
            _context.ExpenseTypes.Remove(entity);
        }
    }
}
