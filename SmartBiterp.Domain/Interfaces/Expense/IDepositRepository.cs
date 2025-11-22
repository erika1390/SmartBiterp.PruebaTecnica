using SmartBiterp.Domain.Entities.Expense;

namespace SmartBiterp.Domain.Interfaces.Expense
{
    public interface IDepositRepository
    {
        Task AddAsync(Deposit entity);
        Task<IEnumerable<Deposit>> GetByDateRangeAsync(DateTime start, DateTime end);
    }
}
