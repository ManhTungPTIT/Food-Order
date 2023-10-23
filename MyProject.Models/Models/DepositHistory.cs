namespace MyProject.Models.Models;

public class DepositHistory: BaseEntity
{
    public decimal DepositAmount { get; set; }
    public int Reason { get; set; }
   
    public int? OrderID { get; set; }
    public Order Order { get; set; }
}