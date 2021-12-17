namespace Transactions.Query.Api.Repositories;

public interface IBalancesRepository
{
    Task<CurrentBalance> GetAsync(Guid accountId);
}
