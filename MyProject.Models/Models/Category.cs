namespace MyProject.Models.Models;

public class Category : BaseEntity
{
    public string? CategoryName { get; set; }
        
    public virtual List<ProductCategory> ProductCategories { get; set; }
}