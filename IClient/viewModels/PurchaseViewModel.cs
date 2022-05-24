using System.ComponentModel.DataAnnotations;
using IClient.BusinessCore;

namespace IClient.viewModels;

public class PurchaseViewModel
{
    [Required]
    public string PurchaseOrder { get; set; }

    [Required]
    public int InventoryId { get; set; }

    [Required]
    public string InventoryName { get; set; }

    [Required]
    public int QuantityToPurchase { get; set; }

    public double InventoryPrice { get; set; }
}