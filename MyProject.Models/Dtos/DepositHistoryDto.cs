using MyProject.Models.Models;

namespace MyProject.Models.Dtos;

public class DepositHistoryDto : BaseDtos
{
    public decimal DepositAmount { get; set; }
    public int Reason { get; set; }
    
    public virtual ICollection<DepositHistory> DepositHistorys { get; set; } 
}