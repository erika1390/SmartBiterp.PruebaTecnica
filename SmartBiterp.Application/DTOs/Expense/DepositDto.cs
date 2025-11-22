namespace SmartBiterp.Application.DTOs.Expense
{
    public class DepositDto
    {
        public int Id { get; set; }
        public int MoneyFundId { get; set; }
        public string MoneyFundName { get; set; } = string.Empty;

        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
