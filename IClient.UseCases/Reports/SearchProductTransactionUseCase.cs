using IClient.BusinessCore;
using IClient.UseCases.PluginsInterfaces;

namespace IClient.UseCases.Reports;

public class SearchProductTransactionUseCase : ISearchProductTransactionUseCase
{
    private readonly IProductTransactionRepository productTransactionRepository;

    public SearchProductTransactionUseCase(IProductTransactionRepository productTransactionRepository)
    {
        this.productTransactionRepository = productTransactionRepository;
    }
    public async Task<IEnumerable<ProductTransaction>> ExecuteAsync(
        string productName,
        DateTime? dateFrom,
        DateTime? dateTo,
        ProductTransactionType? transactionType)
    {
        return await this.productTransactionRepository.GetProductTransactionAsync(
            productName,
            dateFrom,
            dateTo,
            transactionType);
    }
}