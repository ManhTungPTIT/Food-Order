using MyProject.AppService.IService;
using MyProject.DomainService.IRepository;
using MyProject.Models.Models;

namespace MyProject.AppService.Service;

public class OrderProductService : IOrderProductService
{
    private readonly IOrderProductRepository _repository;

    public OrderProductService(IOrderProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<bool> CreateOrderProduct(List<OrderProduct> orderProducts, int userId)
    {
        return await _repository.CreateOrderProduct(orderProducts, userId);
    }

    public async Task<List<Order>> GetOrderByUser(int id)
    {
        return await _repository.GetOrderByUser(id);
    }

    public async Task<List<int>> GetProductIdByOrder(int id)
    {
        return await _repository.GetProductIdByOrderAsync(id);
    }
}