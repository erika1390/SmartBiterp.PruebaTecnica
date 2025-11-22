using Microsoft.EntityFrameworkCore;

using SmartBiterp.Domain.Entities.Expense;
using SmartBiterp.Domain.Interfaces.Expense;
using SmartBiterp.Infrastructure.Persistence.Context;

namespace SmartBiterp.Infrastructure.Repositories.Expense
{
    public class MoneyFundRepository : IMoneyFundRepository
    {
        private readonly AppDbContext _context;

        public MoneyFundRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MoneyFund>> GetAllAsync()
        {
            return await _context.MoneyFunds
                .OrderBy(f => f.Name)
                .ToListAsync();
        }

        public async Task<MoneyFund?> GetByIdAsync(int id)
        {
            return await _context.MoneyFunds.FindAsync(id);
        }

        public async Task AddAsync(MoneyFund entity)
        {
            await _context.MoneyFunds.AddAsync(entity);
        }

        public async Task<string> GetNextCodeAsync()
        {
            var lastCode = await _context.MoneyFunds
                .OrderByDescending(x => x.Id)
                .Select(x => x.Code)
                .FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(lastCode))
                return "MF0001";

            var numberPart = lastCode.Substring(2);

            if (int.TryParse(numberPart, out int number))
            {
                number++;
                return $"MF{number:0000}";
            }
            return "MF0001";
        }

        public void Remove(MoneyFund entity)
        {
            _context.MoneyFunds.Remove(entity);
        }
    }
}
