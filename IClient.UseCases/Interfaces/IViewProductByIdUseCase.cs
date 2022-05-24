using IClient.BusinessCore;

namespace IClient.UseCases;

public interface IViewProductByIdUseCase
{
    Task<Product> ExecuteAsync(int productId);
}