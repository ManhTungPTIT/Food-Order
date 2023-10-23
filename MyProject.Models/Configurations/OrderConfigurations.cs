using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Models.Models;

namespace MyProject.Models.Configurations;

public class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");
        
        builder.HasOne(o => o.User) // Một đơn hàng thuộc về một người dùng
            .WithMany(u => u.Orders) // Một người dùng có nhiều đơn hàng
            .HasForeignKey(o => o.UserId) // Khóa ngoại tham chiếu đến khóa chính ID trong bảng User
            .OnDelete(DeleteBehavior.Restrict); // Cấu hình hành vi xóa

    }
}