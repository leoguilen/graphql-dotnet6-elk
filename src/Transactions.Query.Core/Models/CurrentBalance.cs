namespace Transactions.Query.Api.Models;

public record CurrentBalance
{
    public Guid AccountId { get; init; }

    public decimal Value { get; init; }

    public DateTime Date { get; init; }
}
