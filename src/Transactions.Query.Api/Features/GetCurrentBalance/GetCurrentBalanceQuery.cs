namespace Transactions.Query.Api.Features.GetCurrentBalance;

internal record GetCurrentBalanceQuery(Guid AccountId) : IRequest<CurrentBalance>;
