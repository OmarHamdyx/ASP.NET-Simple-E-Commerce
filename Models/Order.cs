using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Simple_E_Commerce.Models
{
    public class Order : IValidatableObject
    {
        [BindNever]
        public int OrderNo { get; set; }

        [Range(typeof(DateTime), "2000-01-01", "9999-12-31", ErrorMessage = "The date must be greater than or equal to January 1, 2000.")]
        public DateTime? OrderDate { get; set; }

        [Required(ErrorMessage = "The {0} is required.")]
        public double InvoicePrice { get; set; }

        [Required(ErrorMessage = "Please add products")]
        public List<Product>? Products { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (OrderDate == null)
            {
                yield return new ValidationResult("OrderDate can't be blank", new string[] { nameof(OrderDate) });
            }

        }

    }


}
