namespace SmartBiterp.Application.DTOs.Expense
{
    public class CreateDepositRequest
    {
        public DateTime Date { get; set; }
        public int MoneyFundId { get; set; }
        public decimal Amount { get; set; }
    }
}
