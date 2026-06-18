using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_project_as.Models
{
public class Product
{
    [Key]
    public int ProductID { get; set; }

    [Required]
    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    public int Quantity { get; set; }
    public ICollection<Order>? Orders { get; set; }
}
}