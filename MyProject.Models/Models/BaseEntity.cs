namespace MyProject.Models.Models;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set;}
    public DateTime? DeletedOn { get; set; }
}