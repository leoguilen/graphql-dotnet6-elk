namespace Transactions.Query.Infrastructure.Data.Factories;

internal class TransactionHistoryFactory : IFactory<IReadOnlyList<TransactionHistoryDocument>, TransactionHistory[]>
{
    public TransactionHistory[] CreateFrom(IReadOnlyList<TransactionHistoryDocument> source)
    {
        var transactionsHistory = new TransactionHistory[source.Count];

        var sourceEnumerator = source.GetEnumerator();
        for (var currentIndex = 0; sourceEnumerator.MoveNext(); currentIndex++)
        {
            transactionsHistory[currentIndex] = new()
            {
                AccountId = sourceEnumerator.Current.AccountId,
                TransactionId = sourceEnumerator.Current.TransactionId,
                OperationId = sourceEnumerator.Current.OperationId,
                OperationDescription = sourceEnumerator.Current.OperationDescription,
                TransactionDate = sourceEnumerator.Current.TransactionDate,
                TransactionValue = sourceEnumerator.Current.TransactionValue,
            };
        }

        return transactionsHistory;
    }
}
