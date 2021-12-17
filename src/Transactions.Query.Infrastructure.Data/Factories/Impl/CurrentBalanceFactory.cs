namespace Transactions.Query.Infrastructure.Data.Factories;

internal class CurrentBalanceFactory : IFactory<CurrentBalanceDocument, CurrentBalance>
{
    public CurrentBalance CreateFrom(CurrentBalanceDocument source) => new()
    {
        AccountId = source.AccountId,
        Date = source.Date,
        Value = source.Value,
    };
}
