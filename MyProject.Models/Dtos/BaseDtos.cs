namespace MyProject.Models.Dtos;

public class BaseDtos
{
    public int Id { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set;}
    public DateTime? DeletedOn { get; set; }
}