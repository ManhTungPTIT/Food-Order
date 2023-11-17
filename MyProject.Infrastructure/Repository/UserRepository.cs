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

    public async Task<User> GetUserAsync(string name)
    {
        var userData = await Context.Set<User>().FirstOrDefaultAsync(u => u.UserName == name);

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

    public async Task<bool> UpdateInfoUserAsync(User user)
    {
        var data = await Context.Set<User>()
            .Where(u => u.UserName == user.UserName)
            .FirstOrDefaultAsync();

        if (data != null)
        {
            data.Avatar = user.Avatar;
            data.Birthday = user.Birthday;
            data.Address = user.Address;
            data.Phone = user.Phone;

            Context.Set<User>().Update(data);
            await Context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}