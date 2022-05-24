using IClient.BusinessCore;

namespace IClient.UseCases;

public interface ISearchInventoryTransactionsUseCase
{
    Task<IEnumerable<InventoryTransaction>> ExecuteAsync(string inventoryName, DateTime? dateFrom, DateTime? dateTo, InventoryTransactionType? transactionType);
}