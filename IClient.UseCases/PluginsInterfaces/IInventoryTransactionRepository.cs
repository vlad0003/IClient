using IClient.BusinessCore;

namespace IClient.UseCases.PluginsInterfaces;

public interface IInventoryTransactionRepository
{
    Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, double price,string doneBy);

    Task <IEnumerable<InventoryTransaction>> GetInventoryTransactionsAsync(string inventoryName, DateTime? dateFrom,
        DateTime? dateTo, InventoryTransactionType? transactionType);
}