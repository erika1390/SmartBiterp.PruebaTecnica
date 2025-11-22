using SmartBiterp.Domain.Entities.Base;

namespace SmartBiterp.Domain.Entities.Expense
{
    public class Deposit : BaseEntity
    {
        public DateTime Date { get; set; }

        public int MoneyFundId { get; set; }
        public MoneyFund MoneyFund { get; set; } = null!;

        public decimal Amount { get; set; }
    }
}
