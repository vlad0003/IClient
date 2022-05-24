using IClient.BusinessCore;
using IClient.UseCases.PluginsInterfaces;

namespace IClient.UseCases;

public class SellProductUseCase : ISellProductUseCase
{
    private readonly IProductTransactionRepository productTransactionRepository;
    private readonly IProductRepository productRepository;

    public SellProductUseCase(IProductTransactionRepository productTransactionRepository,IProductRepository productRepository)
    {
        this.productTransactionRepository = productTransactionRepository;
        this.productRepository = productRepository;
    }
    public async Task ExecuteAsync(string salesOrderNumber, Product product,int quantity,string doneBy)
    {
       await  this.productTransactionRepository.SellProductAsync(salesOrderNumber,product,quantity,product.Price,doneBy);
        product.Quantity -= quantity;
        await this.productRepository.UpdateProductAsync(product);
    }
}
