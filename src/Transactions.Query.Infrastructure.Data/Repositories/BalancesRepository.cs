namespace Transactions.Query.Infrastructure.Data.Repositories;

internal class BalancesRepository : IBalancesRepository
{
    private const string BalanceCollectionName = "BALANCE";

    private readonly IFactory<CurrentBalanceDocument, CurrentBalance> _currentBalanceFactory;
    private readonly IMongoDatabase _mongoDatabase;
    private readonly IMongoCollection<CurrentBalanceDocument> _balanceCollection;

    public BalancesRepository(
        IMongoDatabase mongoDatabase,
        IFactory<CurrentBalanceDocument, CurrentBalance> currentBalanceFactory)
    {
        _currentBalanceFactory = currentBalanceFactory;
        _mongoDatabase = mongoDatabase;
        _balanceCollection = _mongoDatabase
            .GetCollection<CurrentBalanceDocument>(BalanceCollectionName);
    }

    public async Task<CurrentBalance> GetAsync(Guid accountId)
    {
        var currentBalance = await (await _balanceCollection
            .FindAsync(Builders<CurrentBalanceDocument>
                .Filter
                .EqCaseInsensitive("ACCOUNT_UUID", accountId)))
                .FirstOrDefaultAsync();

        return currentBalance is null
            ? default
            : _currentBalanceFactory.CreateFrom(currentBalance);
    }
}
