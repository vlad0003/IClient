using IClient.UseCases.PluginsInterfaces;

namespace IClient.UseCases;

public class DeleteInventoryUseCase : IDeleteInventoryUseCase
{
    private readonly IInventoryRepository inventoryRepository;

    public DeleteInventoryUseCase(IInventoryRepository inventoryRepository)
    {
        this.inventoryRepository = inventoryRepository;
    }
    
    public async Task ExecuteAsync(int productId)
    {
        await this.inventoryRepository.DeleteInventoryAsync(productId);
    }
}