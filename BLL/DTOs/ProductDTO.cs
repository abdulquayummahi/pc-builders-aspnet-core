using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the product name.")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Please enter the product category.")]
        public string Category { get; set; } = null!;
        [Required(ErrorMessage = "Please enter the product stock.")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Please enter the product price.")]
        public int Price { get; set; }
    }
}
