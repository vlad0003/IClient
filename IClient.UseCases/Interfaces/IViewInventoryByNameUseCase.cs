using IClient.BusinessCore;

namespace IClient.UseCases;

public interface IViewInventoryByNameUseCase
{
    Task<IEnumerable<Inventory>> ExecuteAsync(string name = "");
}