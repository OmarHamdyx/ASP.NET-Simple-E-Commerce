using ASP.NET_Simple_E_Commerce.CustomModelValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Simple_E_Commerce.Models
{
    public class Order //: IValidatableObject
    {
        [BindNever]
        public int OrderNo { get; set; }

        [Display(Name = "Date and Time")]
        [Required(ErrorMessage = "{0} is required.")]
        [Range(typeof(DateTime), "2000-01-01", "9999-12-31", ErrorMessage = "The date must be greater than or equal to January 1, 2000.")]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "Invoice Price")]
        [Required(ErrorMessage = "{0} is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        [InvoiceValidator]
        public double? InvoicePrice { get; set; }

        [Required(ErrorMessage = "Please add products")]
        [AtLeastOneProductValidator]
        public List<Product>? Products { get; set; } = new List<Product>();

  

    }


}
