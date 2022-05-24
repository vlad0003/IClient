using IClient.BusinessCore;
using IClient.UseCases.PluginsInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IClient.PluginsEFCore;

public class ProductRepository : IProductRepository
{
    private readonly IClientContext db;

    public ProductRepository(IClientContext db)
    {
        this.db = db;
    }

    public async Task AddProductAsync(Product product)
    {
        if (db.Products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase))) return ;
        db.Products.Add(product);
        await db.SaveChangesAsync();
        var prods = db.Products.Include(x => x.ProductInventories).ThenInclude(x => x.Inventory).ToList();
    }

    public async Task<List<Product>> GetProductsByName(string name)
    {
        return await this.db.Products.Where(x => (x.ProductName
                .Contains(name,StringComparison.OrdinalIgnoreCase)) || string.IsNullOrWhiteSpace(name) 
                && x.IsActive == true)
            .ToListAsync(); 
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
        return await db.Products.Include(x => x.ProductInventories)
            .ThenInclude(x => x.Inventory)
            .FirstOrDefaultAsync(x => x.ProductId == productId);
    }

    public async Task UpdateProductAsync(Product product)
    {
        if (db.Products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.CurrentCultureIgnoreCase)))
        {
            return;
        }

        var prod = await db.Products.FindAsync(product.ProductId);
        if (prod != null)
        {
            prod.ProductName = product.ProductName;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;
            prod.ProductInventories = product.ProductInventories;

            db.SaveChangesAsync();
        }
    }

    public async Task DeleteProductAsync(int productId)
    {
        var product = await db.Products.FindAsync(productId);
        if (product != null)
        {
            product.IsActive = false;
            db.Products.Remove(product);
            await db.SaveChangesAsync();
        }
    }
}