using IClient.BusinessCore;

namespace IClient.UseCases;

public interface IValidateEnoughInventoriesForProducingUseCase
{
    Task<bool> ExecuteAsync(Product product, int quantity);
}