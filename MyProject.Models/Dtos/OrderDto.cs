using MyProject.Models.Models;

namespace MyProject.Models.Dtos;

public class OrderDto : BaseDtos
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }
    public virtual List<OrderProductDto> OrderProducts { get; set; } 
    public virtual List<Product> Products { get; set; } 
}