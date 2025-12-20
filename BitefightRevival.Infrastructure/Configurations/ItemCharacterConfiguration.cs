using BiteFightRevival.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiteFightRevival.Infrastructure.Configurations;

public class ItemCharacterConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Items");
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(i => i.Description)
            .HasMaxLength(255);

        builder.Property(i => i.Price)
            .IsRequired();

        builder.Property(i => i.Type)
            .IsRequired()
            .HasConversion<string>(); 

        builder.Property(i => i.BonusStrength).HasDefaultValue(0);
        builder.Property(i => i.BonusDefense).HasDefaultValue(0);
        builder.Property(i => i.MinLevelRequired).HasDefaultValue(1);
    }
}