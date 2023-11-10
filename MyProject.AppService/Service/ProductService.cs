using MyProject.AppService.IService;
using MyProject.DomainService.IRepository;
using MyProject.Models.Models;
using MyProject.Models.Request;
using MyProject.Models.Respone;

namespace MyProject.AppService.Service;

public class ProductService : IProductService
{
    private IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResponeProduct> GetAllProduct(int page, int pageSize)
    {
        Request request = new Request
        {
            Page = page,
            PageSize = pageSize
        };
        return await _repository.GetAllProductAsync(request);
    }

    public async Task<bool> AddProduct(Product product)
    {
        return await _repository.AddProductAsync(product);
    }

    public async Task<bool> EditProduct(Product product)
    {
        return await _repository.EditProductAsync(product);
    }

    public async Task<bool> DeleteProduct(int id)
    {
        return await _repository.DeleteProductAsync(id);
    }

    public async Task<Product> GetProductById(int id)
    {
        return await _repository.GetProductByIdAsync(id);
    }
}