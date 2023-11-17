using Microsoft.EntityFrameworkCore;
using MyProject.DomainService.IRepository;
using MyProject.Infrastructure.ApplicationContext;
using MyProject.Models.Dtos;
using MyProject.Models.Models;
using MyProject.Models.Request;
using MyProject.Models.Respone;

namespace MyProject.Infrastructure.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<ResponeProduct> GetAllProductAsync(Request request)
    {
        var respone = new ResponeProduct();
        var query = Context.Set<Product>().Where(d => d.DeletedOn == null);
        var count = await query.CountAsync();

        respone.TotalItem = count;
        respone.TotalPages = (int)Math.Ceiling((double)count / request.PageSize);

        var productDto = await query.Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Image = p.Image,
                ProductName = p.ProductName,
                Price = p.Price,
                Category = p.Category.CategoryName,
            }).ToListAsync();

        respone.ProductDtos = productDto;
        return respone;
    }

    public async Task<bool> AddProductAsync(Product product)
    {
        Context.Set<Product>().Add(product);
        await Context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> EditProductAsync(Product product)
    {
        var productData = await Context.Set<Product>()
            .Where(p => p.ProductName == product.ProductName)
            .FirstOrDefaultAsync();

        if (productData != null)
        {
            productData.ProductName = product.ProductName;
            productData.Price = product.Price;
            
            Context.Set<Product>().Update(productData);
            await Context.SaveChangesAsync();

            return true;
        }

        return false;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await Context.Set<Product>().FirstOrDefaultAsync(p => p.Id == id);
        
        product.DeletedOn = DateTime.Now;
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        var product = await Context.Set<Product>().FirstOrDefaultAsync(p => p.Id == id);

        return product;
    }
}