using MongoDB.Bson;

namespace Transactions.Query.Infrastructure.Data.Extensions;

[ExcludeFromCodeCoverage]
internal static class FilterDefinitionExtensions
{
    public static FilterDefinition<TDocument> Between<TDocument, TItem>(
        this FilterDefinitionBuilder<TDocument> filter,
        string field,
        TItem value1,
        TItem value2) =>
        filter.Gte(field, value1) & filter.Lte(field, value2);

    public static FilterDefinition<TDocument> EqCaseInsensitive<TDocument, TItem>(
        this FilterDefinitionBuilder<TDocument> filter,
        string field,
        TItem value) =>
        filter.Regex(field, new BsonRegularExpression(value?.ToString(), "i"));
}
