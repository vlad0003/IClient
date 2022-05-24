using IClient.BusinessCore;
using IClient.UseCases.PluginsInterfaces;

namespace IClient.UseCases;

public class ViewProductByNameUseCase : IViewProductByNameUseCase 
{
    private readonly IProductRepository productRepository;
    public ViewProductByNameUseCase(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task<List<Product>> ExecuteAsync(string name = "")
    {
        return await this.productRepository.GetProductsByName(name);
    }
    
} 