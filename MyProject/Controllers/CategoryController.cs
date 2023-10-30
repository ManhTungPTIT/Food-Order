using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers;

public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}