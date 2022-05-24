using IClient.BusinessCore;
using IClient.UseCases.PluginsInterfaces;

namespace IClient.UseCases;

public class ValidateEnoughInventoriesForProducingUseCase : IValidateEnoughInventoriesForProducingUseCase
{
    private readonly IProductRepository productRepository;

    public ValidateEnoughInventoriesForProducingUseCase(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task<bool> ExecuteAsync(Product product, int quantity)
    {
        var prod = await productRepository.GetProductByIdAsync(product.ProductId);
        foreach (var pi in prod.ProductInventories)
        {
            if (pi.InventoryQuantity * quantity > pi.Inventory.Quantity)
                return false;
        }

        return true;
    }
}