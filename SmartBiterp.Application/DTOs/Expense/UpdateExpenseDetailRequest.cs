namespace SmartBiterp.Application.DTOs.Expense
{
    public class UpdateExpenseDetailRequest
    {
        public int Id { get; set; }
        public int ExpenseTypeId { get; set; }
        public decimal Amount { get; set; }
    }
}
