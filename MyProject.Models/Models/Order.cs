namespace MyProject.Models.Models;

public class Order : BaseEntity
{
    public string UserId { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }

    public virtual User User { get; set; }
    
    public virtual ICollection<OrderProduct> OrderProducts { get; set; } 
    
    public virtual ICollection<DepositHistory> DepositHistories { get; set; }
}