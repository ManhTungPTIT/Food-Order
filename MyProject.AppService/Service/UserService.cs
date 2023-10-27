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
    public async Task<User> GetUser(User user)
    {
        return await _repository.GetUserAsync(user);
    }
}