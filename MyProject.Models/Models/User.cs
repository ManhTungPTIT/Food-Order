namespace MyProject.Models.Models;

public class User
{
    public string Name { get; set; }
    public string? Avatar { get; set; }
    public string UserId { get; set; }
    public bool IsAdmin { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public DateTime? CreatedOn { get; set; }
        
    public DateTime? UpdatedOn { get; set; }
        
    public DateTime? DeletedOn { get; set; }
        
    public virtual ICollection<Order> Orders { get; set; }
}