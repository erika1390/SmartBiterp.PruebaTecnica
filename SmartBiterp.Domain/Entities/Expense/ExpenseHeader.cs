using SmartBiterp.Domain.Entities.Base;
using SmartBiterp.Domain.Enums;

namespace SmartBiterp.Domain.Entities.Expense
{
    public class ExpenseHeader : BaseEntity
    {
        public DateTime Date { get; set; }

        public int MoneyFundId { get; set; }
        public MoneyFund MoneyFund { get; set; } = null!;

        public string StoreName { get; set; } = string.Empty;
        public DocumentType DocumentType { get; set; }
        public string? Notes { get; set; }

        public ICollection<ExpenseDetail> Details { get; set; } = new List<ExpenseDetail>();
    }
}
