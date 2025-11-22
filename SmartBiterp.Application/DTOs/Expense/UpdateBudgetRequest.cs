using SmartBiterp.Domain.Enums;

namespace SmartBiterp.Application.DTOs.Expense
{
    public class UpdateBudgetRequest
    {
        public int Id { get; set; }
        public decimal AllocatedAmount { get; set; }
        public BudgetStatusType Status { get; set; }
    }
}
