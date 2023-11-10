using MyProject.Models.Models;

namespace MyProject.DomainService.IRepository;

public interface IOrderProductRepository
{
    Task<bool> CreateOrderProduct(List<OrderProduct> orderProducts, int userId);
}