using IClient.BusinessCore;

namespace IClient.UseCases;

public interface IProduceProductUseCase
{
    Task ExecuteAsync(string productionNumber, Product product, int quantity,string doneBy);
}