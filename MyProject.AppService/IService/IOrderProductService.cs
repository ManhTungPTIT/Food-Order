using MyProject.Models.Models;

namespace MyProject.AppService.IService;

public interface IOrderProductService
{
    Task<bool> CreateOrderProduct(List<OrderProduct> orderProducts, int userId);
}