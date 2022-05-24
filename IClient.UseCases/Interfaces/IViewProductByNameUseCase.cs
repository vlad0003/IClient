using IClient.BusinessCore;

namespace IClient.UseCases;

public interface IViewProductByNameUseCase
{
    Task<List<Product>> ExecuteAsync(string name = "");
}