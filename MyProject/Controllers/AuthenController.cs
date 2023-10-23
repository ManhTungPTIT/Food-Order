using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers
{
    public class AuthenController : Controller
    {
       
        
        public IActionResult Login()
        {
            return View();
        }
        
        public IActionResult Register()
        {
            return View();
        }
    }
}
