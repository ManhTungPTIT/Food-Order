using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Models.Models;

namespace MyProject.Models.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        
        builder.HasMany(u => u.Orders) // Một người dùng có nhiều đơn hàng
            .WithOne(o => o.User) // Mỗi đơn hàng thuộc về một người dùng
            .HasForeignKey(o => o.UserId) // Khóa ngoại tham chiếu đến khóa chính ID trong bảng Order
            .OnDelete(DeleteBehavior.Restrict); // Cấu hình hành vi xóa
        
    }
}