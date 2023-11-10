namespace MyProject.Models.Dtos;

public class ProductDto : BaseDtos
{
    public string? ProductName { get; set; }

    public string? Image { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    
}