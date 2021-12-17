namespace Transactions.Query.Api.Features.GetTransactionsHistory;

internal class GetTransactionsHistoryQueryHandler : IRequestHandler<GetTransactionsHistoryQuery, TransactionHistory[]>
{
    private readonly ITransactionsHistoryRepository _transactionsHistoryRepository;

    public GetTransactionsHistoryQueryHandler(ITransactionsHistoryRepository transactionsHistoryRepository)
        => _transactionsHistoryRepository = transactionsHistoryRepository;

    public async Task<TransactionHistory[]> Handle(GetTransactionsHistoryQuery request, CancellationToken cancellationToken)
        => await _transactionsHistoryRepository.GetAsync(request.AccountId, request.StartDate, request.EndDate);
}
