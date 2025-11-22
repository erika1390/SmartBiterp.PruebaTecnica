namespace SmartBiterp.Application.DTOs.Expense
{
    public class ExpenseTypeDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
