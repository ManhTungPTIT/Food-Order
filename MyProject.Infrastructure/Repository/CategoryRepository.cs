using Microsoft.EntityFrameworkCore;
using MyProject.DomainService.IRepository;
using MyProject.Infrastructure.ApplicationContext;
using MyProject.Models.Models;

namespace MyProject.Infrastructure.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<Category>> GetAllCategoryAsync()
    {
        var list = await Context.Set<Category>()
            .Where(p => p.DeletedOn == null)
            .Select(p => new Category
            {
                Id = p.Id,
                CategoryName = p.CategoryName,
            }).ToListAsync();

        return list;
    }

    public async Task<bool> AddCategoryAsync(Category category)
    {
        Context.Set<Category>().Add(category);
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EditCategoryAsync(Category category)
    {
        var data = await Context.Set<Category>()
            .FirstOrDefaultAsync(p => p.Id == category.Id);
        if (data != null)
        {
            data.CategoryName = category.CategoryName;
            Context.Set<Category>().Update(data);
            await Context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var data = await Context.Set<Category>().FirstOrDefaultAsync(p => p.Id == id);
        if (data != null)
        {
            data.DeletedOn = DateTime.Now;
            Context.Set<Category>().Update(data);
            await Context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}