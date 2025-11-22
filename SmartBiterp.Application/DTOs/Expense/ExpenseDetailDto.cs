namespace SmartBiterp.Application.DTOs.Expense
{
    public class ExpenseDetailDto
    {
        public int ExpenseTypeId { get; set; }
        public string ExpenseTypeName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
