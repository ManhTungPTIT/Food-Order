using MyProject.AppService.IService;
using MyProject.DomainService.IRepository;
using MyProject.Models.Models;

namespace MyProject.AppService.Service;

public class AuthenService : IAuthenService
{
    private readonly IAuthenRepository _repository;

    public AuthenService(IAuthenRepository repository)
    {
        _repository = repository;
    }
    public async Task<bool> Login(User user)
    {
        return await _repository.LoginAsync(user);
    }

    public async Task<bool> Register(User user)
    {
        return await _repository.RegisterAsync(user);
    }
}