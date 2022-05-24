using IClient.BusinessCore;

namespace IClient.UseCases;

public interface IViewInventoryById
{
    Task<Inventory?> ExecuteAsync(int inventoryId);
}