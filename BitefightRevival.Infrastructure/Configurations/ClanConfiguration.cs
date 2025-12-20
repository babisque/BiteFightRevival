using BiteFightRevival.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiteFightRevival.Infrastructure.Configurations;

public class ClanConfiguration : IEntityTypeConfiguration<Clan>
{
    public void Configure(EntityTypeBuilder<Clan> builder)
    {
        builder.ToTable("Clans");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Tag).IsRequired().HasMaxLength(4);
        builder.Property(c => c.Description).HasMaxLength(500);
        builder.Property(c => c.Treasury).IsRequired().HasDefaultValue(0);
        
        builder.HasMany(c => c.Characters)
            .WithOne(c => c.Clan)
            .HasForeignKey(c => c.ClanId);
        
        builder.Property(c => c.LeaderId).IsRequired();
    }
}