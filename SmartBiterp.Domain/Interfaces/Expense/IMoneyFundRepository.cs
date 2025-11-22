using SmartBiterp.Domain.Entities.Expense;

namespace SmartBiterp.Domain.Interfaces.Expense
{
    public interface IMoneyFundRepository
    {
        Task<IEnumerable<MoneyFund>> GetAllAsync();
        Task<MoneyFund?> GetByIdAsync(int id);
        Task AddAsync(MoneyFund entity);
        Task<string> GetNextCodeAsync();
        void Remove(MoneyFund entity);
    }
}
