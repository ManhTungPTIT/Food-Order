using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProject.DomainService.IRepository;
using MyProject.Infrastructure.ApplicationContext;
using MyProject.Models.Models;

namespace MyProject.Infrastructure.Repository;

public class AuthenRepository : Repository<User>, IAuthenRepository
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthenRepository(ApplicationDbContext context, UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager) : base(context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }


    public async Task<bool> LoginAsync(User user)
    {
        var userData = await _userManager.FindByNameAsync(user.UserName);
        if (userData != null)
        {
            await _signInManager.SignInAsync(userData, isPersistent: true);
            var checkRole =  await _userManager.GetRolesAsync(userData);
            return true;
        }

        return false;
    }

    public async Task<bool> RegisterAsync(User user)
    {
        //Kiểm tra xem tài khoản đã tồn tại chưa
        var checkUser = await Context.Set<User>()
            .Where(u => u.UserName == user.UserName)
            .FirstOrDefaultAsync();
        if (checkUser != null)
        {
            return false;
        }
        
        //Kiem tra xem tai khoản dăng ký la admin hay nhân viên
        if (user.UserName.Contains("@admin")) //chua cum ky tu nay thi la admin
        {
            
            var newAdmin = new IdentityUser()
            {
                UserName = user.UserName,
                Email = user.UserName,
            };
            
            Context.Set<User>().Add(user);
            var check = await _userManager.CreateAsync(newAdmin, user.Password);
            var roleExists = await _roleManager.RoleExistsAsync("ADMIN");

            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole("ADMIN"));
            }

            var checkRole = await _userManager.AddToRoleAsync(newAdmin, "ADMIN");
            
        }
        else
        {
            var employeeIdentity = new IdentityUser
            {
                UserName = user.UserName,
                PasswordHash = user.Password,
                Email = user.UserName,
            };
            Context.Set<User>().Add(user);
            await _userManager.CreateAsync(employeeIdentity);

            var roleExists = await _roleManager.RoleExistsAsync("USER");


            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole("USER"));
            }

            var result = await _userManager.AddToRoleAsync(employeeIdentity, "USER");
            
        }


        await Context.SaveChangesAsync();
        return true;
    }
}