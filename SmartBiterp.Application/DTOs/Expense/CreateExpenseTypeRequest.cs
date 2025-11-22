namespace SmartBiterp.Application.DTOs.Expense
{
    public class CreateExpenseTypeRequest
    {
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
