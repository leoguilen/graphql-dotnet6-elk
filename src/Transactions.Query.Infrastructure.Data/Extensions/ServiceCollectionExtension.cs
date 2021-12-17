namespace Transactions.Query.Infrastructure.Data.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfraData(this IServiceCollection services) =>
        services
            .ConfigureMongoConnection()
            .AddSingleton<IFactory<CurrentBalanceDocument, CurrentBalance>, CurrentBalanceFactory>()
            .AddSingleton<IFactory<IReadOnlyList<TransactionHistoryDocument>, TransactionHistory[]>, TransactionHistoryFactory>()
            .AddScoped<IBalancesRepository, BalancesRepository>()
            .AddScoped<ITransactionsHistoryRepository, TransactionsHistoryRepository>();

    private static IServiceCollection ConfigureMongoConnection(this IServiceCollection services) =>
        services
            .AddScoped(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var mongoUrl = MongoUrl.Create(configuration.GetConnectionString("MongoDb"));
                var mongoDatabase = mongoUrl.DatabaseName;

                return new MongoClient(mongoUrl)
                    .GetDatabase(mongoDatabase);
            });
}
