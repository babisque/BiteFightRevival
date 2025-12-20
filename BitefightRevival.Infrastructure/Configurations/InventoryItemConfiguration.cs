using BiteFightRevival.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiteFightRevival.Infrastructure.Configurations;

public class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
{
    public void Configure(EntityTypeBuilder<InventoryItem> builder)
    {
        builder.ToTable("InventoryItems");
        builder.HasKey(ii => ii.Id);

        builder.HasOne(ii => ii.Item)
            .WithMany()
            .HasForeignKey(ii => ii.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Character>()
            .WithMany(c => c.Inventory)
            .HasForeignKey(ii => ii.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasIndex(ii => ii.CharacterId);
    }
}