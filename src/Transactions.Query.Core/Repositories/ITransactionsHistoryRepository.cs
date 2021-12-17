namespace Transactions.Query.Api.Repositories;

public interface ITransactionsHistoryRepository
{
    Task<TransactionHistory[]> GetAsync(Guid accountId, DateOnly startDate, DateOnly endDate);
}
