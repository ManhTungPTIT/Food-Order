using MyProject.Models.Models;

namespace MyProject.AppService.IService;

public interface IAuthenService
{
    Task<bool> Login(User user);
    Task<bool> Register(User user);
}