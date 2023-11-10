using MyProject.Models.Models;

namespace MyProject.AppService.IService;

public interface IUserService
{
    Task<User> GetUser(User user);
    Task<int> GetUserId(string name);
}