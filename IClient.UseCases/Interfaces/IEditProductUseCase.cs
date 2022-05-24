using IClient.BusinessCore;

namespace IClient.UseCases;

public interface IEditProductUseCase
{
    Task ExecuteAsync(Product product);
}