using MyProject.Models.Models;

namespace MyProject.DomainService.IRepository;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetUserAsync(string name);
    Task<int> GetUserIdAsync(string name);
    Task<bool> UpdateInfoUserAsync(User user);
}