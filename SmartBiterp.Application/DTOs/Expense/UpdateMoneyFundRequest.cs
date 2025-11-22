namespace SmartBiterp.Application.DTOs.Expense
{
    public class UpdateMoneyFundRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FundType { get; set; } = string.Empty;
        public decimal InitialBalance { get; set; }
    }
}
