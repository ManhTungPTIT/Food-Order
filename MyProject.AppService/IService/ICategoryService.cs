using MyProject.Models.Dtos;
using MyProject.Models.Models;

namespace MyProject.AppService.IService;

public interface ICategoryService
{
    Task<List<Category>> GetAllCategory();
    Task<bool> AddCategory(Category category);
    Task<bool> EditCategory(Category category);
    Task<bool> DeleteCategory(int id);
}