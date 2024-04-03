using ASP.NET_Simple_E_Commerce.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ASP.NET_Simple_E_Commerce.CustomModelValidation
{
    public class InvoiceValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                double invoice = Convert.ToDouble(value);
                PropertyInfo? propertyReference = validationContext.ObjectType.GetProperty("Products");
                if (propertyReference != null)
                {
                    object? productsValue = propertyReference.GetValue(validationContext.ObjectInstance);

                    List<Product> products = (List<Product>)productsValue;
           
                    double? total, sum = 0;

                    foreach (Product product in products)
                    {
                        if (product.Quantity==null)
                        {
                            return null;
                        }
                        total = product.Price * (double)product.Quantity;
                        sum += total;
                    }
                    if (sum == invoice)
                    {
                        return ValidationResult.Success;
                    }
                    else if (products.Count!=0) 
                    {
                        return new ValidationResult("Please add correct Product prices or Invoice Price",new string[] {nameof(validationContext.MemberName) } );
                    }
                }
                return null;
            }
            return null;
        }
    }
}
