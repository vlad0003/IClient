
using IClient.BusinessCore;

namespace IClient.UseCases;

public interface IAddProductUseCase
{
    Task ExecuteAsync(Product product);
}