using Microsoft.EntityFrameworkCore;
using MyProject.DomainService.IRepository;
using MyProject.Infrastructure.ApplicationContext;
using MyProject.Models.Models;

namespace MyProject.Infrastructure.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<User> GetUserAsync(User user)
    {
        var userData = await Context.Set<User>().FirstOrDefaultAsync(u => u.UserName == user.UserName);

        return userData;
    }

    public async Task<int> GetUserIdAsync(string name)
    {
        var id = await Context.Set<User>()
                .Where(u => u.UserName == name)
                .Select(u => u.ID)
                .FirstOrDefaultAsync();
        return id;
    }
}