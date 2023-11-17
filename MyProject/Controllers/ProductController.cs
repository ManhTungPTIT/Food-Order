using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.AppService.IService;
using MyProject.Models.Dtos;
using MyProject.Models.Models;

namespace MyProject.Controllers;

[Authorize]
[Authorize(Roles = "ADMIN")]
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
    public async Task<IActionResult> ListProduct()
    {
        int page = 1;
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

    public async Task<IActionResult> CreateProduct(string name, decimal price, string avatar, int categoryName)
    {
        var newProduct = new Product
        {
            Image = avatar,
            ProductName = name,
            Price = price,
            CategoryId = categoryName,
            CreatedOn = DateTime.Now,
        };

        await _productService.AddProduct(newProduct);
        return RedirectToAction("ListProduct");
    }
    public async Task<IActionResult> EditProduct(string name, decimal price, string avatar, int categoryName)
    {
        var newProduct = new Product
        {
            Image = avatar,
            ProductName = name,
            Price = price,
            CategoryId = categoryName,
            CreatedOn = DateTime.Now,
        };

        await _productService.EditProduct(newProduct);
        return View("ListProduct");
    }

    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteProduct(id);
        return RedirectToAction("ListProduct");
    }
}