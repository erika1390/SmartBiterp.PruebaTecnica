using SmartBiterp.Domain.Enums;

namespace SmartBiterp.Application.DTOs.Expense
{
    public class CreateExpenseHeaderRequest
    {
        public DateTime Date { get; set; }
        public int MoneyFundId { get; set; }
        public string StoreName { get; set; } = string.Empty;
        public string Observations { get; set; } = string.Empty;
        public DocumentType DocumentType { get; set; }

        public List<CreateExpenseDetailRequest> Details { get; set; }
            = new List<CreateExpenseDetailRequest>();
    }
}
