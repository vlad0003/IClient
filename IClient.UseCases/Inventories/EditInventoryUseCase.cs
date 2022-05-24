using System.Runtime.InteropServices;
using IClient.BusinessCore;
using IClient.UseCases.PluginsInterfaces;

namespace IClient.UseCases;

public class EditInventoryUseCase : IEditInventoryUseCase
{
    private readonly IInventoryRepository inventoryRepository;

    public EditInventoryUseCase(IInventoryRepository inventoryRepository)
    {
        this.inventoryRepository = inventoryRepository;
    }

    public async Task ExecuteAsync(Inventory inventory)
    {
        await this.inventoryRepository.UpdateInventoryAsync(inventory);
    }
}
