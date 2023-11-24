using MyProject.Models.Models;

namespace MyProject.Models.Dtos;

public class OrderProductDto : BaseDtos
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal SubTotal { get; set; }

    public virtual OrderDto Order { get; set; }
    public virtual IEnumerable<ProductDto> Product { get; set; }
   
}