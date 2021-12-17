namespace Transactions.Query.Infrastructure.Data.Models;

internal record TransactionHistoryDocument
{
    [BsonId]
    public ObjectId Id { get; internal init; }

    [BsonRequired]
    [BsonElement("TRANSACTION_UUID")]
    [BsonRepresentation(BsonType.String)]
    [BsonGuidRepresentation(GuidRepresentation.CSharpLegacy)]
    public Guid TransactionId { get; internal init; }

    [BsonRequired]
    [BsonElement("ACCOUNT_UUID")]
    [BsonRepresentation(BsonType.String)]
    [BsonGuidRepresentation(GuidRepresentation.CSharpLegacy)]
    public Guid AccountId { get; internal init; }

    [BsonRequired]
    [BsonElement("OPERATION_UUID")]
    [BsonRepresentation(BsonType.String)]
    [BsonGuidRepresentation(GuidRepresentation.CSharpLegacy)]
    public Guid OperationId { get; internal init; }

    [BsonRequired]
    [BsonElement("OPERATION_DESCRIPTION")]
    public string OperationDescription { get; internal init; }

    [BsonRequired]
    [BsonElement("TRANSACTION_VALUE")]
    public decimal TransactionValue { get; internal init; }

    [BsonRequired]
    [BsonElement("TRANSACTION_DATE")]
    public DateTime TransactionDate { get; internal init; }
}
