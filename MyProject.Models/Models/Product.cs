namespace MyProject.Models.Models;

public class Product : BaseEntity
{
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public string? Image { get; set; }
        
    public virtual List<ProductCategory> ProductCategories { get; set; }
}