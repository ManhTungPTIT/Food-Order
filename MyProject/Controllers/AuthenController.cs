using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProject.AppService.IService;
using MyProject.Models.Models;

namespace MyProject.Controllers
{
    public class AuthenController : Controller
    {
        private readonly IAuthenService _authenService;

        public AuthenController(IAuthenService authenService)
        {
            _authenService = authenService;
        }
        
        public async Task<IActionResult> Login(string? UserName, string? Password)
        {
            
            if (UserName != null)
            {
                var user = new User
                {
                    UserName = UserName,
                    Password = Password
                };
                var check = await _authenService.Login(user);
                if (check && UserName.Contains("@admin"))
                {
                    return Redirect("/Product/ListProduct");
                }
                else if (check)
                {
                    return Redirect("/Profile/Index");
                }
                else
                {
                    var mess = "Tài khoản không tồn tại hoặc thông tin đăng nhập không chính xác";
                    return RedirectToAction("Register", routeValues: new { mess });
                }
            }
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(string? userName, string? password, string? phone, DateTime? birthday)
        
        {
            
            if (userName != null && password != null && phone !=  null && birthday != null)
            {
                var user = new User
                {
                    UserName = userName,
                    Password = password,
                    Phone = phone,
                    Birthday = birthday,
                    CreatedOn = DateTime.Now,
                };
                var check = await _authenService.Register(user);
                if (check)
                {
                    return Redirect("/Profile/Index");
                }
                else
                {
                    var mess = "Tài khoản đã tồn tại";
                    return RedirectToAction("Register", routeValues: new { mess });
                }
            }
            return View();
        }
        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return View("Login");
        }

    }
}
