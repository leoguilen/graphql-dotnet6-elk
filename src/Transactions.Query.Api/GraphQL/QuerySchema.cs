namespace Transactions.Query.Api.GraphQL;

internal class QuerySchema : Schema
{
    public QuerySchema(IServiceProvider servicesProvider)
        : base(servicesProvider)
        => Query = servicesProvider.GetRequiredService<Query>();
}
