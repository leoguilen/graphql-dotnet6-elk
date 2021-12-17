namespace Transactions.Query.Api.Features.GetTransactionsHistory;

internal record GetTransactionsHistoryQuery(Guid AccountId, DateOnly StartDate, DateOnly EndDate) : IRequest<TransactionHistory[]>;
