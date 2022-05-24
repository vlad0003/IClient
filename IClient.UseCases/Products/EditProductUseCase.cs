using IClient.BusinessCore;
using IClient.UseCases.PluginsInterfaces;

namespace IClient.UseCases;

public class EditProductUseCase : IEditProductUseCase
{
    private readonly IProductRepository productRepository;

    public EditProductUseCase(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    
    public async Task ExecuteAsync(Product product)
    {
        await this.productRepository.UpdateProductAsync(product);
    }
}   