namespace Transactions.Query.Api.GraphQL.Types;

internal class CurrentBalanceObject : ObjectGraphType<CurrentBalance>
{
    public CurrentBalanceObject()
    {
        Name = nameof(CurrentBalance);
        Description = "The current balance of some account";

        Field(cb => cb.AccountId).Description("The id of the account");
        Field(cb => cb.Value).Description("The current value of the account balance");
        Field(cb => cb.Date).Description("The date of the last balance modification");
    }
}
