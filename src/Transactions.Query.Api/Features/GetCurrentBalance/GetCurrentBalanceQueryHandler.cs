namespace Transactions.Query.Api.Features.GetCurrentBalance;

internal class GetCurrentBalanceQueryHandler : IRequestHandler<GetCurrentBalanceQuery, CurrentBalance>
{
    private readonly IBalancesRepository _balancesRepository;

    public GetCurrentBalanceQueryHandler(IBalancesRepository balancesRepository)
        => _balancesRepository = balancesRepository;

    public async Task<CurrentBalance> Handle(GetCurrentBalanceQuery request, CancellationToken cancellationToken)
        => await _balancesRepository.GetAsync(request.AccountId);
}
