using MyProject.Models.Models;
using MyProject.Models.Request;
using MyProject.Models.Respone;

namespace MyProject.AppService.IService;

public interface IProductService
{
    Task<ResponeProduct> GetAllProduct(int page, int pageSize);
    Task<bool> AddProduct(Product product);
    Task<bool> EditProduct(Product product);
    Task<bool> DeleteProduct(int id);
}