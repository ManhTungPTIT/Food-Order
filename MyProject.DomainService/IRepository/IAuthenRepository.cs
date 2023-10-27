using MyProject.Models.Models;

namespace MyProject.DomainService.IRepository;

public interface IAuthenRepository : IRepository<User>
{
    Task<bool> LoginAsync(User user);
    Task<bool> RegisterAsync(User user);
}