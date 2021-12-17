namespace Transactions.Query.Api.GraphQL;

internal class Query : ObjectGraphType<object>
{
    public Query(IMediator mediator)
    {
        Name = nameof(Query);

        _ = FieldAsync<ListGraphType<TransactionsHistoryObject>>(
            name: "getTransactionsHistory",
            description: "Get transactions history of one account",
            arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<GuidGraphType>>
                    {
                        Name = "accountId",
                        Description = "The unique GUID of the account.",
                    },
                    new QueryArgument<NonNullGraphType<DateGraphType>>
                    {
                        Name = "startDate",
                        Description = "The transactions history start date.",
                    },
                    new QueryArgument<NonNullGraphType<DateGraphType>>
                    {
                        Name = "endDate",
                        Description = "The transactions history end date.",
                    }),
            resolve: async context =>
            {
                var accountId = context.GetArgument("accountId", Guid.Empty);
                var startDate = DateOnly.FromDateTime(context.GetArgument("startDate", DateTime.MinValue));
                var endDate = DateOnly.FromDateTime(context.GetArgument("endDate", DateTime.MinValue));

                return await mediator.Send(new GetTransactionsHistoryQuery(accountId, startDate, endDate));
            });

        _ = FieldAsync<CurrentBalanceObject, CurrentBalance>(
            name: "getCurrentBalance",
            description: "Get the current balance of one account",
            arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<GuidGraphType>>
                    {
                        Name = "accountId",
                        Description = "The unique GUID of the account.",
                    }),
            resolve: async context =>
            {
                var accountId = context.GetArgument("accountId", Guid.Empty);
                return await mediator.Send(new GetCurrentBalanceQuery(accountId));
            });
    }
}
