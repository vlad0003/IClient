using IClient.BusinessCore;

namespace IClient.UseCases;

public interface IEditInventoryUseCase
{
    Task ExecuteAsync(Inventory inventory);
}