using IClient.BusinessCore;

namespace IClient.UseCases.PluginsInterfaces;

public interface IInventoryRepository
{
    Task<IEnumerable<Inventory>> GetInventoriesByName(string name);
    Task<Inventory> GetInventoryByIdAsync(int inventoryId);
    Task AddInventoryAsync(Inventory inventory);
    Task UpdateInventoryAsync(Inventory inventory);
}