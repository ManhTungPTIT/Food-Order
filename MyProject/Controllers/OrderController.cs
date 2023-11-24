using Microsoft.AspNetCore.Mvc;
using MyProject.AppService.IService;
using MyProject.Models.Dtos;

namespace MyProject.Controllers;

public class OrderController : Controller
{
    private readonly IOrderProductService _orderProductService;

    public OrderController(IOrderProductService orderProductService)
    {
        _orderProductService = orderProductService;
    }
    public async Task<IActionResult> Index()
    {
        var day = DateTime.Now.ToString("yyyy-MM-dd");
        var listOrder = await _orderProductService.GetOrderFinishByDay(day);
        var listQuan = await _orderProductService.GetQuantityProductByOrder(listOrder);
        ViewBag.ListOrder = listOrder;
        ViewBag.ListQuantity = listQuan;
        return View();
    }

    
}