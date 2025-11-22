namespace SmartBiterp.Application.DTOs.Expense
{
    public class CreateMoneyFundRequest
    {
        public string Name { get; set; } = string.Empty;
        public string FundType { get; set; } = string.Empty;
        public decimal InitialBalance { get; set; }
    }
}
