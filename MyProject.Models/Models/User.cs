namespace MyProject.Models.Models;

public class User
{
    public int ID { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string? Phone { get; set; }
    public string? Avatar { get; set; }
    public string? Address { get; set; }
    public DateTime? Birthday { get; set; }
    public DateTime? CreatedOn { get; set; }
        
    public DateTime? UpdatedOn { get; set; }
        
    public DateTime? DeletedOn { get; set; }
        
    public virtual ICollection<Order> Orders { get; set; }
}