using IClient.BusinessCore;
using IClient.UseCases.PluginsInterfaces;

namespace IClient.UseCases.Reports;

public class SearchInventoryTransactionsUseCase : ISearchInventoryTransactionsUseCase
{
    private readonly IInventoryTransactionRepository inventoryTransactionRepository;

    public SearchInventoryTransactionsUseCase(IInventoryTransactionRepository inventoryTransactionRepository)
    {
        this.inventoryTransactionRepository = inventoryTransactionRepository;
    }

    public async Task<IEnumerable<InventoryTransaction>> ExecuteAsync
    (
        string inventoryName,
        DateTime? dateFrom,
        DateTime? dateTo,
        InventoryTransactionType? transactionType
    )
    {
         return await  this.inventoryTransactionRepository.GetInventoryTransactionsAsync(inventoryName,dateFrom,dateTo,transactionType);
    }
    
}