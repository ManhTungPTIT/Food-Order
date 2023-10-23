using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Models.Models;

namespace MyProject.Models.Configurations;

public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> builder)
    {
        builder.ToTable("OrderProduct");

        builder.HasOne(op => op.Order) // Một sản phẩm đặt hàng thuộc về một đơn hàng
            .WithMany(o => o.OrderProducts) // Một đơn hàng có nhiều sản phẩm đặt hàng
            .HasForeignKey(op => op.OrderId) // Khóa ngoại tham chiếu đến khóa chính ID trong bảng Order
            .OnDelete(DeleteBehavior.Restrict); // Cấu hình hành vi xóa

        builder.HasOne(op => op.Product) // Một sản phẩm đặt hàng liên kết với một sản phẩm
            .WithMany() // Một sản phẩm không liên kết trở lại sản phẩm đặt hàng
            .HasForeignKey(op => op.ProductId) // Khóa ngoại tham chiếu đến khóa chính ID trong bảng Product
            .OnDelete(DeleteBehavior.Restrict); // Cấu hình hành vi xóa
    }
    
}