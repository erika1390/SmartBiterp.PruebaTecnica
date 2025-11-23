namespace SmartBiterp.Application.DTOs.Expense
{
    public class CreateExpenseDetailRequest
    {
        public int ExpenseTypeId { get; set; }
        public decimal Amount { get; set; }
    }
}
