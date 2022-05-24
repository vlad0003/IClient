using IClient.BusinessCore;
using IClient.UseCases.PluginsInterfaces;

namespace IClient.UseCases;

public class ViewInventoryByNameUseCase : IViewInventoryByNameUseCase
{
    private readonly IInventoryRepository inventoryRepository;
    public ViewInventoryByNameUseCase(IInventoryRepository inventoryRepository)
    {
        this.inventoryRepository = inventoryRepository;
    }
    public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
    {
        return await this.inventoryRepository.GetInventoriesByName(name);
    }
}
