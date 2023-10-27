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
            var user = new User
            {
                UserName = UserName,
                Password = Password
            };
            if (UserName != null)
            {
                var check = await _authenService.Login(user);
                if (check)
                {
                    return Redirect("/Home/Index");
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
        public async Task<IActionResult> Register(string? userName, string? password)
        {
            
            if (userName != null && password != null )
            {
                var user = new User
                {
                    UserName = userName,
                    Password = password,
                    Phone = "01234567",
                    Birthday = DateTime.Now,
                    CreatedOn = DateTime.Now,
                };
                var check = await _authenService.Register(user);
                if (check)
                {
                    return Redirect("/Home/Index");
                }
                else
                {
                    var mess = "Tài khoản đã tồn tại";
                    return RedirectToAction("Register", routeValues: new { mess });
                }
            }
            return View();
        }
    }
}
