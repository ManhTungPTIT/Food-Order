using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Models.Models;

namespace MyProject.Models.Configurations;

public class DepisitHistoryConfigurations : IEntityTypeConfiguration<DepositHistory>
{
    public void Configure(EntityTypeBuilder<DepositHistory> builder)
    {
        builder.ToTable("DepositHistory");

        builder.HasOne<Order>(s => s.Order)
            .WithMany(g => g.DepositHistories)
            .HasForeignKey(d => d.OrderID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}