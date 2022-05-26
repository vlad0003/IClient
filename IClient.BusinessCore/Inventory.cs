using System.ComponentModel.DataAnnotations;

namespace IClient.BusinessCore;

public class Inventory
{
    public int InventoryId { get; set; }
    [Required]
    public string? Inventoryname { get; set; }
    public int Quantity { get; set; }
    [Range(0,Double.MaxValue,ErrorMessage = "Цена должна быть больше или равна {0}")]
    public double Price { get; set; }

    public List<ProductInventory>? ProductInventories { get; set; }
}