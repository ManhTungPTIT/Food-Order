using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers;

public class ProductController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CreateProduct()
    {
        return View("Index");
    }
    public IActionResult EditProduct()
    {
        return View("Index");
    }
}