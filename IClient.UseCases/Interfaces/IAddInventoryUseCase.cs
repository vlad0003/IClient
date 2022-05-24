using IClient.BusinessCore;

namespace IClient.UseCases;

public interface IAddInventoryUseCase
{
    Task ExecuteAsync(Inventory inventory);
}