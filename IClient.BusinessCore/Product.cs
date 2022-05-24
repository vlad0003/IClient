using System.ComponentModel.DataAnnotations;
using IClient.BusinessCore.Validation;

namespace IClient.BusinessCore;

public class Product
{
    public int ProductId { get; set; }
    [Required]
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    [Range(0,Double.MaxValue,ErrorMessage = "Price must be greater or equal to {0}")]
    [ProductInventoryPrice]
    public double Price { get; set; }

    public bool IsActive { get; set; } = true;
    public List<ProductInventory>? ProductInventories { get; set; }

    public double TotalInventoryCost()
    {
        return  this.ProductInventories.Sum(x => x.Inventory?.Price * x.InventoryQuantity ?? 0);

    }

    public bool ValidatingPricing()
    {
        if (ProductInventories == null || ProductInventories.Count <= 0)
        {
            return true;
        }
        
        if (this.TotalInventoryCost() > Price)
        {
            return false;
        }

        return true;
    }
}