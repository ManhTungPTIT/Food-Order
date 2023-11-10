using MyProject.DomainService.IRepository;
using MyProject.Infrastructure.ApplicationContext;
using MyProject.Models.Models;

namespace MyProject.Infrastructure.Repository;

public class OrderRepository : Repository<OrderProduct>, IOrderProductRepository
{
    public OrderRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> CreateOrderProduct(List<OrderProduct> orderProducts, int userId)
    {
        decimal totalAmount = orderProducts.Sum(op => op.Quantity * op.Price);

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
            orderProduct.Price = orderProduct.Product.Price;
            await CreateOrderProduct(orderProduct);
        }
        
        return true;
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
}