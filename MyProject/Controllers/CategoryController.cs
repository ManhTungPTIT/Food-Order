using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.AppService.IService;
using MyProject.Models.Models;

namespace MyProject.Controllers;

[Authorize]
[Authorize(Roles = "ADMIN")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var list = await _categoryService.GetAllCategory();
        ViewBag.ListCate = list;
        return View();
    }

    public async Task<IActionResult> AddCategory(string name)
    {
        var category = new Category
        {
            CategoryName = name,
        };
        await _categoryService.AddCategory(category);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> EditCategory(string categoryName, int categoryId)
    {
        var category = new Category
        {
            Id = categoryId,
            CategoryName = categoryName,
        };
        var check = await _categoryService.EditCategory(category);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var check = await _categoryService.DeleteCategory(id);
        return RedirectToAction("Index");
    }
}