namespace Transactions.Query.Infrastructure.Data.Models;

internal class CurrentBalanceDocument
{
    [BsonId]
    public ObjectId Id { get; internal init; }

    [BsonRequired]
    [BsonElement("ACCOUNT_UUID")]
    [BsonRepresentation(BsonType.String)]
    [BsonGuidRepresentation(GuidRepresentation.CSharpLegacy)]
    public Guid AccountId { get; internal init; }

    [BsonRequired]
    [BsonElement("BALANCE_VALUE")]
    public decimal Value { get; internal init; }

    [BsonRequired]
    [BsonElement("BALANCE_DATE")]
    public DateTime Date { get; internal init; }
}
