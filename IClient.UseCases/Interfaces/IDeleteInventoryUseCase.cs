namespace IClient.UseCases;

public interface IDeleteInventoryUseCase
{
    Task ExecuteAsync(int inventoryId);
}