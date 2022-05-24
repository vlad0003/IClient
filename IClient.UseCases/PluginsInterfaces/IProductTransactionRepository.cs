using IClient.BusinessCore;

namespace IClient.UseCases.PluginsInterfaces;

public interface IProductTransactionRepository
{
    Task ProduceAsync(string productionNumber, Product product, int quantity, double price, string doneBy);
    Task SellProductAsync(string salesOrderNumber, Product product, int quantity, double price,string doneBy);

    Task<IEnumerable<ProductTransaction>> GetProductTransactionAsync(string productName, DateTime? dateFrom,
        DateTime? dateTo, ProductTransactionType? transactionType);
}