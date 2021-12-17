namespace Transactions.Query.Api.GraphQL.Types;

internal class TransactionsHistoryObject : ObjectGraphType<TransactionHistory>
{
    public TransactionsHistoryObject()
    {
        Name = nameof(TransactionHistory);
        Description = "The transaction history item of some account";

        Field(cb => cb.TransactionId).Description("The id of the transaction");
        Field(cb => cb.AccountId).Description("The id of the account");
        Field(cb => cb.OperationId).Description("The id of the operation");
        Field(cb => cb.OperationDescription).Description("The description of the operation");
        Field(cb => cb.TransactionValue).Description("The value of the transaction");
        Field(cb => cb.TransactionDate).Description("The date of the transaction");
    }
}
