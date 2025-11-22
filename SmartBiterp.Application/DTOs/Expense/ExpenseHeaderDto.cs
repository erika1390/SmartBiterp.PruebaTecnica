namespace SmartBiterp.Application.DTOs.Expense
{
    public class ExpenseHeaderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int MoneyFundId { get; set; }
        public string MoneyFundName { get; set; } = string.Empty;

        public string DocumentType { get; set; } = string.Empty;
        public string StoreName { get; set; } = string.Empty;
        public string Observations { get; set; } = string.Empty;

        public List<ExpenseDetailDto> Details { get; set; } = new();
    }
}
