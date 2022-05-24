using IClient.BusinessCore;

namespace IClient.UseCases.PluginsInterfaces;

public interface IProductRepository
{
    Task AddProductAsync(Product product);
    
    public Task<List<Product>> GetProductsByName(string name);
    Task<Product> GetProductByIdAsync(int productId);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(int productId);
}