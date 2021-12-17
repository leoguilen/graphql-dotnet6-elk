namespace Transactions.Query.Api.Models;

public record TransactionHistory
{
    public Guid TransactionId { get; init; }

    public Guid AccountId { get; init; }

    public Guid OperationId { get; init; }

    public string OperationDescription { get; init; }

    public decimal TransactionValue { get; init; }

    public DateTime TransactionDate { get; init; }
}
