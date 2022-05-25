using System.ComponentModel.DataAnnotations;

namespace IClient.BusinessCore;

public class ProductTransaction
{
    public int ProductTransactionId { get; set; }
    [Required]
    public ProductTransactionType ActivityType { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int QuantityBefore { get; set; }
    [Required]
    public int QuantityAfter { get; set; }
    [Required]
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    [Required]
    public string DoneBy { get; set; }
    public Product Product { get; set; }
    public string? SalesOrderNumber { get; set; }
    public string? ProductionNumber { get; set; }
    
    public double? UnitPrice { get; set; }
}