using MyProject.Models.Dtos;
using MyProject.Models.Models;

namespace MyProject.DomainService.IRepository;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllCategoryAsync();
    Task<bool> AddCategoryAsync(Category category);
    Task<bool> EditCategoryAsync(Category category);
    Task<bool> DeleteCategoryAsync(int id);
}