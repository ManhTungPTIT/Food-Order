namespace MyProject.Models.Dtos;

public class OrderProductDto : BaseDtos
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal SubTotal { get; set; }

    public virtual OrderDto Order { get; set; }
    public virtual ProductDto Product { get; set; }
}