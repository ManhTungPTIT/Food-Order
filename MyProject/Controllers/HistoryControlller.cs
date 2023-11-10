using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers;

public class HistoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}