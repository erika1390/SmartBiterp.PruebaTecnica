using SmartBiterp.Domain.Entities.Base;
using SmartBiterp.Domain.Enums;

namespace SmartBiterp.Domain.Entities.Expense
{
    public class ExpenseType : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ExpenseCategoryType Category { get; set; } = ExpenseCategoryType.Other;

        public ICollection<ExpenseDetail> ExpenseDetails { get; set; } = new List<ExpenseDetail>();
        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    }
}
