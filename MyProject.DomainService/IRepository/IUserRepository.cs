using MyProject.Models.Models;

namespace MyProject.DomainService.IRepository;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetUserAsync(User user);
}