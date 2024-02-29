using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Simple_E_Commerce.Models
{
    public class Product : IValidatableObject
    {
        [Display(Name = "Product Code")]
        [Required(ErrorMessage = "The {0} is required.")]

        public int ProductCode { get; set; }

        [Required(ErrorMessage = "The {0} is required.")]

        public double Price { get; set; }

        [Required(ErrorMessage = "The {0} is required.")]

        public int Quantity { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            if (Price <= 0)
            {
                yield return new ValidationResult("Product Price must be between a valid number", new string[] { nameof(Price) });
            }
            if (Quantity <= 0)
            {
                yield return new ValidationResult("Product Quantity must be between a valid number", new string[] { nameof(Quantity) });
            }
        }
    }
}
