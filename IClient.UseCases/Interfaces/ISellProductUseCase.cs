using IClient.BusinessCore;

namespace IClient.UseCases;

public interface ISellProductUseCase
{
    Task ExecuteAsync(string salesOrderNumber, Product product, int quantity, string doneBy);
}