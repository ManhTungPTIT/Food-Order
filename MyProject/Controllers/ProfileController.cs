using Microsoft.AspNetCore.Mvc;
using MyProject.AppService.IService;
using MyProject.Models.Models;

namespace MyProject.Controllers;

public class ProfileController : Controller
{
    private readonly IUserService _userService;

    public ProfileController(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<IActionResult> Index(User? user)
    {
        var getUser = await _userService.GetUser(user);
        ViewBag.GetUser = getUser;
        return View();
    }
}