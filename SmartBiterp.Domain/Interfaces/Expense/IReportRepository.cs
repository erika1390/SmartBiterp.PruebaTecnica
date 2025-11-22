namespace SmartBiterp.Domain.Interfaces.Expense
{
    public interface IReportRepository
    {
        Task<IEnumerable<object>> GetBudgetVsExecutionAsync(DateTime start, DateTime end);
        Task<IEnumerable<object>> GetMovementsAsync(DateTime start, DateTime end);
    }
}
