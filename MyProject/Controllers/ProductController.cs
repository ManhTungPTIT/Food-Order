using Microsoft.AspNetCore.Mvc;
using MyProject.AppService.IService;
using MyProject.Models.Dtos;
using MyProject.Models.Models;

namespace MyProject.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }
    // GET
    public async Task<IActionResult> ListProduct(int page = 1)
    {
        var pageSize = 3;
        var response = await _productService.GetAllProduct(page, pageSize);
        var categories = await _categoryService.GetAllCategory();
        
        ViewBag.TotalPages = response.TotalPages;
        ViewBag.CurrentPage = page;
        ViewBag.PageSize = pageSize;
        ViewBag.TotalItem = response.TotalItem;
        ViewBag.ListItem = response.ProductDtos;
        ViewBag.ListCate = categories;
        return View(response.ProductDtos);
    }
    
    public async Task<List<ProductDto>> UpdateListProduct(int page)
    {
        var pageSize = 3;
        var response = await _productService.GetAllProduct(page, pageSize);
        return response.ProductDtos;
    }

    public async Task<IActionResult> CreateProduct(string name, decimal price, string avatar, int[] categories)
    {
        var dataCate = await _categoryService.GetAllCategory();
        var selectCate = dataCate.Where(c => categories.Contains(c.Id)).ToList();

       
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