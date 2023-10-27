using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers;

public class MenuController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}