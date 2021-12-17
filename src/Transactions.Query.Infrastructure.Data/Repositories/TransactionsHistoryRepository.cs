namespace Transactions.Query.Infrastructure.Data.Repositories;

internal class TransactionsHistoryRepository : ITransactionsHistoryRepository
{
    private const string TransactionsHistoryCollectionName = "TRANSACTIONS_HISTORY";

    private readonly IFactory<IReadOnlyList<TransactionHistoryDocument>, TransactionHistory[]> _transactionHistoryFactory;
    private readonly IMongoDatabase _mongoDatabase;
    private readonly IMongoCollection<TransactionHistoryDocument> _transactionHistoryCollection;

    public TransactionsHistoryRepository(
        IMongoDatabase mongoDatabase,
        IFactory<IReadOnlyList<TransactionHistoryDocument>, TransactionHistory[]> transactionHistoryFactory)
    {
        _transactionHistoryFactory = transactionHistoryFactory;
        _mongoDatabase = mongoDatabase;
        _transactionHistoryCollection = _mongoDatabase
            .GetCollection<TransactionHistoryDocument>(TransactionsHistoryCollectionName);
    }

    public async Task<TransactionHistory[]> GetAsync(Guid accountId, DateOnly startDate, DateOnly endDate)
    {
        var filterDefinition = startDate == DateOnly.MinValue
                               || endDate == DateOnly.MinValue
            ? Builders<TransactionHistoryDocument>.Filter.EqCaseInsensitive("ACCOUNT_UUID", accountId)
            : Builders<TransactionHistoryDocument>.Filter.And(
                Builders<TransactionHistoryDocument>.Filter.EqCaseInsensitive("ACCOUNT_UUID", accountId),
                Builders<TransactionHistoryDocument>.Filter.Between(
                    field: "TRANSACTION_DATE",
                    value1: startDate.ToDateTime(TimeOnly.MinValue),
                    value2: endDate.ToDateTime(TimeOnly.MinValue)));

        var transactionsHistory = await (await _transactionHistoryCollection
            .FindAsync(filterDefinition))
            .ToListAsync();

        return _transactionHistoryFactory
            .CreateFrom(transactionsHistory);
    }
}
