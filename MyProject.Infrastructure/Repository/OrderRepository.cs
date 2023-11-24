using System.Globalization;
using Microsoft.EntityFrameworkCore;
using MyProject.DomainService.IRepository;
using MyProject.Infrastructure.ApplicationContext;
using MyProject.Models.Dtos;
using MyProject.Models.Models;

namespace MyProject.Infrastructure.Repository;

public class OrderRepository : Repository<OrderProduct>, IOrderProductRepository
{
    public OrderRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> CreateOrderProduct(List<OrderProduct> orderProducts, int userId)
    {
        decimal totalAmount = orderProducts.Sum(op => op.Quantity * op.Product.Price);

        var order = new Order
        {
            UserId = userId,
            TotalAmount = totalAmount,
            Status = "Finish",
            CreatedOn = DateTime.Now,
        };

        await CreateOrder(order);

        foreach (var orderProduct in orderProducts)
        {
            var existingProduct = await Context.Set<Product>().FindAsync(orderProduct.ProductId); //Lay thong tin product qua productID
            if (existingProduct != null)
            {
                orderProduct.Product = existingProduct;
            }

            orderProduct.OrderId = order.Id;
            orderProduct.CreatedOn = DateTime.Now;
            orderProduct.SubTotal = totalAmount;
            orderProduct.Price = orderProduct.Product.Price;
            await CreateOrderProduct(orderProduct);
        }
        
        return true;
    }

    public async Task<List<Order>> GetOrderByUser(int id)
    {
        var list = await Context.Set<Order>()
            .Where(o => o.UserId == id && o.DeletedOn == null)
            .ToListAsync();
        return list;
    }

    public async Task CreateOrder(Order order)
    {
        Context.Set<Order>().Add(order);
        await Context.SaveChangesAsync();
    }
    
    public async Task CreateOrderProduct(OrderProduct orderProduct)
    {
        Context.Set<OrderProduct>().Add(orderProduct);
        await Context.SaveChangesAsync();
    }

    public async Task<List<int>> GetProductIdByOrderAsync(int id)
    {
        var list = await Context.Set<OrderProduct>()
            .Where(op => op.OrderId == id)
            .Select(p => p.ProductId)
            .ToListAsync();
        return list;
    }

    public async Task<List<OrderDto>> GetAllOrderByDayAsync(string day)
    {
        DateTime dayRequest;
        if (DateTime.TryParseExact(day, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out dayRequest))
        {
            DateTime endDate = dayRequest.AddDays(1);
            var list = await Context.Set<Order>()
                .Where(o => o.CreatedOn >= dayRequest && o.DeletedOn < endDate)
                .Select(op => new OrderDto
                {
                    TotalAmount = op.TotalAmount,
                    Products = op.OrderProducts.Select(src => new Product
                    {
                        ProductName = src.Product.ProductName,
                        Price = src.Product.Price,
                    }).ToList()
                }).ToListAsync();

            return list;
        }
        return null;
    }

    public async Task<List<OrderDto>> GetOrderFinishByDayAsync(string day)
    {
        DateTime dayRequest;
        if (DateTime.TryParseExact(day, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out dayRequest))
        {
            DateTime endDate = dayRequest.AddDays(1);
            var list = await Context.Set<Order>()
                .Where(or => or.CreatedOn >= dayRequest && or.CreatedOn < endDate)
                .Select(or => new OrderDto
                {
                    Id = or.Id,
                    UserName = or.User.UserName,
                    TotalAmount = or.TotalAmount,
                }).ToListAsync();

            return list;
        }
        return null;
    }

    public async Task<List<OrderProductDto>> GetQuantityProductByOrderAsync(List<OrderDto> order)
    {
        List<int> orderId = order.Select(or => or.Id).ToList();

        var quantity = await Context.Set<OrderProduct>()
            .Where(op => orderId.Contains(op.OrderId))
            .Select(op => new OrderProductDto
            {
                OrderId = op.OrderId,
                Quantity = op.Quantity,
                Price = op.Price,
                ProductName = op.Product.ProductName,
            }).ToListAsync();

        return quantity;
    }

    
}