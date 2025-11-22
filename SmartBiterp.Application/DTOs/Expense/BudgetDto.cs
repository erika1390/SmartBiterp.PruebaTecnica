namespace SmartBiterp.Application.DTOs.Expense
{
    public class BudgetDto
    {
        public int Id { get; set; }
        public int ExpenseTypeId { get; set; }
        public string ExpenseTypeName { get; set; } = string.Empty;

        public int Year { get; set; }
        public int Month { get; set; }

        public decimal AllocatedAmount { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
