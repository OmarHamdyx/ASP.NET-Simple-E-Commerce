using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Simple_E_Commerce.Models
{
    public class Product
    {
        [Display(Name = "Product Code")]
        [Required(ErrorMessage = "{0} is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be between a valid number")]

        public int? ProductCode { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be between a valid number")]

        public double? Price { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be between a valid number")]

        public int? Quantity { get; set; }

       
    }
}
