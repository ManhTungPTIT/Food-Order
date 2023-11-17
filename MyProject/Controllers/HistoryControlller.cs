using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProject.AppService.IService;
using MyProject.Models.Dtos;
using MyProject.Models.Models;

namespace MyProject.Controllers;

[Authorize]
[Authorize(Roles = "USER")]
public class HistoryController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    private readonly IOrderProductService _orderProductService;
    private readonly IUserService _userService;
    private readonly IProductService _productService;

    public HistoryController(UserManager<IdentityUser> userManager, IOrderProductService orderProductService, IUserService userService, IProductService productService)
    {
        _userManager = userManager;
        _orderProductService = orderProductService;
        _userService = userService;
        _productService = productService;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var name = User.Identity?.Name;
        var userId = await _userService.GetUserId(name);

        var list = await _orderProductService.GetOrderByUser(userId);
        ViewBag.ListOrder = list;
        return View();
    }

    public async Task<List<Product>> GetDetailOrder(int id)
    {
        var list = new List<Product>();
        var listId = await _orderProductService.GetProductIdByOrder(id);
        foreach (var productId in listId)
        {
            var produt = await _productService.GetProductById(productId);
            list.Add(produt);
        }
        return list;
    }
}