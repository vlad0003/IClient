using System.ComponentModel.DataAnnotations;
using IClient.BusinessCore;

namespace IClient.viewModels;

public class SellViewModel
{
    [Required]
    public string SalesOrderNumber { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public string ProductName { get; set; }

    [Required]
    [Range(minimum:1,maximum:int.MaxValue,ErrorMessage = "Кол-во должно быть больше или равное 1")]
    public int QuantityToSell { get; set; }

    [Required]
    [Range(minimum:0,maximum:int.MaxValue,ErrorMessage = "Цена должна быть больше или равна стоимости продукта")]
    public double ProductPrice { get; set; }
}