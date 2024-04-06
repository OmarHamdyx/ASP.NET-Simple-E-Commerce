using ASP.NET_Simple_E_Commerce.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ASP.NET_Simple_E_Commerce.CustomModelValidation
{
    public class AtLeastOneProductValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                List<Product> products = (List<Product>)value;
                if (products.Count == 0)
                {
                    return new ValidationResult("Please add Products");
                }
                return ValidationResult.Success;  
            }
            return null;
        }
    }
}