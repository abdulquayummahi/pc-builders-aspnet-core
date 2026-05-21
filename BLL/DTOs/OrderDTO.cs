using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int UnitPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Status { get; set; }
    }
}
