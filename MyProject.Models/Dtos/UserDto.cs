using MyProject.Models.Models;

namespace MyProject.Models.Dtos;

public class UserDto : BaseDtos
{
    public string UserId { get; set; }
    
    public string UserName { get; set; }
    
    public virtual ICollection<User> Users { get; set; } 
}