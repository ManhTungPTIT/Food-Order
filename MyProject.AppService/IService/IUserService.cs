using MyProject.Models.Models;

namespace MyProject.AppService.IService;

public interface IUserService
{
    Task<User> GetUser(string name);
    Task<int> GetUserId(string name);
    Task<bool> UpdateInfoUser(User user);
}