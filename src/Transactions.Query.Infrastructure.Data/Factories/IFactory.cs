namespace Transactions.Query.Infrastructure.Data.Factories;

internal interface IFactory<TSource, TFrom>
{
    TFrom CreateFrom(TSource source);
}
