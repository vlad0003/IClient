using IClient.BusinessCore;

namespace IClient.UseCases;

public interface IPurchaseInventoryUseCase
{
    Task ExecuteAsync(string poNumber, Inventory inventory, int quantity, string doneBy);
}