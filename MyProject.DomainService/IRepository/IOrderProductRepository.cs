using MyProject.Models.Dtos;
using MyProject.Models.Models;

namespace MyProject.DomainService.IRepository;

public interface IOrderProductRepository
{
    Task<bool> CreateOrderProduct(List<OrderProduct> orderProducts, int userId);
    Task<List<Order>> GetOrderByUser(int id);
    Task<List<int>> GetProductIdByOrderAsync(int id);
    Task<List<OrderDto>> GetAllOrderByDayAsync(string day);
    Task<List<OrderDto>> GetOrderFinishByDayAsync(string day);
    Task<List<OrderProductDto>> GetQuantityProductByOrderAsync(List<OrderDto> order);
}