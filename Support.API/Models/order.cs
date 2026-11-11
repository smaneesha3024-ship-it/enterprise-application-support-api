using System.ComponentModel.DataAnnotations;

namespace Support.API.Models;

public class Order
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Customer name is required")]
    [StringLength(100)]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "SKU is required")]
    public string SKU { get; set; } = string.Empty;

    [Range(1, 10000, ErrorMessage = "Quantity must be between 1 and 10000")]
    public int Quantity { get; set; }

    [RegularExpression("^(Pending|Processing|Shipped|Cancelled)$",
        ErrorMessage = "Invalid order status")]
    public string Status { get; set; } = "Pending";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}