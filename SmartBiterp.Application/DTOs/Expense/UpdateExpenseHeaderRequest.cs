using SmartBiterp.Domain.Enums;

namespace SmartBiterp.Application.DTOs.Expense
{
    public class UpdateExpenseHeaderRequest
    {
        public int Id { get; set; } 
        public DateTime Date { get; set; } 
        public int MoneyFundId { get; set; } 
        public string StoreName { get; set; } = string.Empty;
        public string Observations { get; set; } = string.Empty;

        public DocumentType DocumentType { get; set; }

        // Si se permite actualizar detalles:
        public List<UpdateExpenseDetailRequest> Details { get; set; } = new();
    }
}
