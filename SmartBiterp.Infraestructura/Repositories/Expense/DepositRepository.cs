using Microsoft.EntityFrameworkCore;

using SmartBiterp.Domain.Entities.Expense;
using SmartBiterp.Domain.Interfaces.Expense;
using SmartBiterp.Infrastructure.Persistence.Context;

namespace SmartBiterp.Infrastructure.Repositories.Expense
{
    public class DepositRepository : IDepositRepository
    {
        private readonly AppDbContext _context;

        public DepositRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Deposit entity)
        {
            if (entity.Amount <= 0)
                throw new ArgumentException("Deposit amount must be greater than zero.");

            await _context.Deposits.AddAsync(entity);
        }

        public async Task<IEnumerable<Deposit>> GetByDateRangeAsync(DateTime start, DateTime end)
        {
            return await _context.Deposits
                .Where(d => d.Date >= start && d.Date <= end)
                .ToListAsync();
        }
    }
}
