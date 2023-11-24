using MyProject.Models.Dtos;
using MyProject.Models.Models;

namespace MyProject.AppService.IService;

public interface IOrderProductService
{
    Task<bool> CreateOrderProduct(List<OrderProduct> orderProducts, int userId);
    Task<List<Order>> GetOrderByUser(int id);
    Task<List<int>> GetProductIdByOrder(int id);
    Task<List<OrderDto>> GetOrderFinishByDay(string day);
    Task<List<OrderProductDto>> GetQuantityProductByOrder(List<OrderDto> order);
}