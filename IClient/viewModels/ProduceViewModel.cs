using System.ComponentModel.DataAnnotations;

namespace IClient.viewModels;

public class ProduceViewModel
{
    [Required]
    public string ProductionNumber { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public string ProductName { get; set; }

    [Required]
    public int QuantityToProduce { get; set; }

    public double ProductPrice { get; set; }
}