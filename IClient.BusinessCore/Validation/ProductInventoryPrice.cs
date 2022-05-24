using System.ComponentModel.DataAnnotations;

namespace IClient.BusinessCore.Validation;

internal class ProductInventoryPrice : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var product = validationContext.ObjectInstance as Product;
        if (product != null)
        {
            if (!product.ValidatingPricing())
            {
                return new ValidationResult($"цена продукта ниже чем стоимость в инвентаре {product.TotalInventoryCost()}",
                    new[]{validationContext.MemberName});
            }
        }

        return ValidationResult.Success;
    }
}