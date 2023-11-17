using MyProject.Models.Models;

namespace MyProject.Models.Dtos;

public class OrderDto : BaseDtos
{
    public string UserId { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }
    public virtual ICollection<OrderProduct> OrderProducts { get; set; } 
    public virtual ICollection<Product> Products { get; set; } 
}