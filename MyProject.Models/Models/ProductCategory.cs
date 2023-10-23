namespace MyProject.Models.Models;

public class ProductCategory : BaseEntity
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }

    public DateTime? CreatedOn { get; set; }
        
    public DateTime? UpdatedOn { get; set; }
        
    public DateTime? DeletedOn { get; set; }

    public virtual Product Product { get; set; }

    public virtual Category Category { get; set; }
}