using System.Security.Cryptography;
using MyProject.AppService.IService;
using MyProject.DomainService.IRepository;
using MyProject.Models.Models;

namespace MyProject.AppService.Service;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<Category>> GetAllCategory()
    {
        return await _repository.GetAllCategoryAsync();
    }

    public async Task<bool> AddCategory(Category category)
    {
        return await _repository.AddCategoryAsync(category);
    }

    public async Task<bool> EditCategory(Category category)
    {
        return await _repository.EditCategoryAsync(category);
    }

    public async Task<bool> DeleteCategory(int id)
    {
        return await _repository.DeleteCategoryAsync(id);
    }
}