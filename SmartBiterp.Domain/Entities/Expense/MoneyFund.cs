using SmartBiterp.Domain.Entities.Base;
using SmartBiterp.Domain.Enums;

namespace SmartBiterp.Domain.Entities.Expense
{
    public class MoneyFund : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public FundType FundType { get; set; }
        public ICollection<ExpenseHeader> ExpenseHeaders { get; set; } = new List<ExpenseHeader>();
        public ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();
    }
}
