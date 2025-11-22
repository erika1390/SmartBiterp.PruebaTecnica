using SmartBiterp.Domain.Entities.Base;

namespace SmartBiterp.Domain.Entities.Expense
{
    public class ExpenseDetail : BaseEntity
    {
        public int ExpenseHeaderId { get; set; }
        public ExpenseHeader ExpenseHeader { get; set; } = null!;

        public int ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; } = null!;

        public decimal Amount { get; set; }
    }
}
