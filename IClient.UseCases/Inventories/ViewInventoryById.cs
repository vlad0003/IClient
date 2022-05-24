using IClient.BusinessCore;
using IClient.UseCases.PluginsInterfaces;

namespace IClient.UseCases;

public class ViewInventoryById : IViewInventoryById
{
    private readonly IInventoryRepository inventoryRepository;

    public ViewInventoryById(IInventoryRepository inventoryRepository)
    {
        this.inventoryRepository = inventoryRepository;
    }

    public async Task<Inventory?> ExecuteAsync(int InventoryId)
    {
        return await this.inventoryRepository.GetInventoryByIdAsync(InventoryId);
    }
    
}