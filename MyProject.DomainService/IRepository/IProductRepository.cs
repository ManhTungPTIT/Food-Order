using MyProject.Models.Models;
using MyProject.Models.Request;
using MyProject.Models.Respone;

namespace MyProject.DomainService.IRepository;

public interface IProductRepository
{
    Task<ResponeProduct> GetAllProductAsync(Request request);
    Task<bool> AddProductAsync(Product product);
    Task<bool> EditProductAsync(Product product);
    Task<bool> DeleteProductAsync(int id);
}