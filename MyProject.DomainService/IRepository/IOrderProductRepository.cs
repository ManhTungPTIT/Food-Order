using MyProject.Models.Dtos;
using MyProject.Models.Models;

namespace MyProject.DomainService.IRepository;

public interface IOrderProductRepository
{
    Task<bool> CreateOrderProduct(List<OrderProduct> orderProducts, int userId);
    Task<List<Order>> GetOrderByUser(int id);
    Task<List<int>> GetProductIdByOrderAsync(int id);
}