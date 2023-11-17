using MyProject.AppService.IService;
using MyProject.DomainService.IRepository;
using MyProject.Models.Models;

namespace MyProject.AppService.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<User> GetUser(string name)
    {
        return await _repository.GetUserAsync(name);
    }

    public async Task<int> GetUserId(string name)
    {
        return await _repository.GetUserIdAsync(name);
    }

    public async Task<bool> UpdateInfoUser(User user)
    {
        return await _repository.UpdateInfoUserAsync(user);
    }
}