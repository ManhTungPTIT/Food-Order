namespace MyProject.Models.Models;

public class Product : BaseEntity
{
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public string? Image { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
        
    
}