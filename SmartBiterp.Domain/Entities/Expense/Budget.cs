using SmartBiterp.Domain.Entities.Base;
using SmartBiterp.Domain.Enums;

namespace SmartBiterp.Domain.Entities.Expense
{
    public class Budget : BaseEntity
    {
        public int ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; } = null!;

        public int Year { get; set; }
        public int Month { get; set; }

        public decimal AllocatedAmount { get; set; }

        public BudgetStatusType Status { get; set; } = BudgetStatusType.Normal;
    }
}