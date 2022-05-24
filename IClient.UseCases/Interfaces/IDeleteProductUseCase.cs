namespace IClient.UseCases;

public interface IDeleteProductUseCase
{
    Task ExecuteAsync(int productId);
}