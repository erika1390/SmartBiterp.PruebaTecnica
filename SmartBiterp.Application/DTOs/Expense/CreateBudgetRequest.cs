namespace SmartBiterp.Application.DTOs.Expense
{
    public class CreateBudgetRequest
    {
        public int ExpenseTypeId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal AllocatedAmount { get; set; }
    }
}
