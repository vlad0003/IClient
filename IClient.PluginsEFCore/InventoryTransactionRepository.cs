using IClient.BusinessCore;
using IClient.UseCases.PluginsInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IClient.PluginsEFCore;

public class InventoryTransactionRepository :IInventoryTransactionRepository
{
    private readonly IClientContext db;

    public InventoryTransactionRepository(IClientContext db)
    {
        this.db = db;
    }
    public async Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, double price,string doneBy)
    {
        this.db.InventoryTransactions.Add(new InventoryTransaction
        {
            PONumber = poNumber,
            InventoryId = inventory.InventoryId,
            QuantityBefore = inventory.Quantity,
            ActivityType = InventoryTransactionType.PurchaseInventory,
            QuantityAfter = inventory.Quantity + quantity,
            TransactionDate = DateTime.UtcNow,
            DoneBy = doneBy,
            UnitPrice = price
        });
        await this.db.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<InventoryTransaction>> GetInventoryTransactionsAsync(
        string inventoryName, 
        DateTime? dateFrom, 
        DateTime? dateTo, 
        InventoryTransactionType? transactionType)
    {
        if (dateTo.HasValue) dateTo = dateTo.Value.AddDays(1);

        var query = from it in db.InventoryTransactions
            join inv in db.Inventories on it.InventoryId equals inv.InventoryId
            where 
                (string.IsNullOrWhiteSpace(inventoryName) || inv.Inventoryname.ToLower().IndexOf(inventoryName.ToLower()) >= 0) &&
                (!dateFrom.HasValue || it.TransactionDate >= dateFrom.Value.Date) &&
                (!dateTo.HasValue || it.TransactionDate <= dateTo.Value.Date) &&
                (!transactionType.HasValue || it.ActivityType == transactionType)
            select it;

        return await query.Include(x => x.Inventory).ToListAsync();
    }        

    
}