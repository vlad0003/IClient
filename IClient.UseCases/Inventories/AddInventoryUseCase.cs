using IClient.BusinessCore;
using IClient.UseCases.PluginsInterfaces;

namespace IClient.UseCases;

public class AddInventoryUseCase : IAddInventoryUseCase
{
    private readonly IInventoryRepository inventoryRepository;

    public AddInventoryUseCase(IInventoryRepository inventoryRepository)
    {
        this.inventoryRepository = inventoryRepository;
    }
    
    public async Task ExecuteAsync(Inventory inventory)
    {
        await inventoryRepository.AddInventoryAsync(inventory);
    }
}