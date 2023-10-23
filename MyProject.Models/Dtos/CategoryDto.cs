namespace MyProject.Models.Dtos;

public class CategoryDto : BaseDtos
{
    public string? CategoryName { get; set; }
    public ICollection<ProductDto>? Products { get; set; }
}