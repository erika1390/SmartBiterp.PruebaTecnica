using SmartBiterp.Application.DTOs.Expense;

namespace SmartBiterp.Application.Interfaces.Expense
{
    public interface IMoneyFundService
    {
        Task<IEnumerable<MoneyFundDto>> GetAllAsync();
        Task<MoneyFundDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateMoneyFundRequest request);
        Task UpdateAsync(UpdateMoneyFundRequest request);
        Task DeleteAsync(int id);
        Task<string> GetNextCodeAsync();
    }
}
