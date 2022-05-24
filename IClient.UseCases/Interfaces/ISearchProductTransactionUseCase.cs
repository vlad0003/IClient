using IClient.BusinessCore;

namespace IClient.UseCases;

public interface ISearchProductTransactionUseCase
{
    Task<IEnumerable<ProductTransaction>> ExecuteAsync(string productName, DateTime? dateFrom, DateTime? dateTo, ProductTransactionType? transactionType);
}