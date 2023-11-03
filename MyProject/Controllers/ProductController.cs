using Microsoft.AspNetCore.Mvc;
using MyProject.AppService.IService;

namespace MyProject.Controllers;

public class ProductController : Controller
{
    private IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    // GET
    public async Task<IActionResult> ListProduct(int page = 1)
    {
        var pageSize = 5;
        var response = await _productService.GetAllProduct(page, pageSize);
        
        ViewBag.TotalPages = response.TotalPages;
        ViewBag.CurrentPage = page;
        ViewBag.PageSize = pageSize;
        ViewBag.TotalItem = response.TotalItem;
        ViewBag.ListItem = response.ProductDtos;
        return View(response.ProductDtos);
    }

    public IActionResult CreateProduct()
    {
        return View("ListProduct");
    }
    public IActionResult EditProduct()
    {
        return View("ListProduct");
    }

    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteProduct(id);
        return RedirectToAction("ListProduct");
    }
}