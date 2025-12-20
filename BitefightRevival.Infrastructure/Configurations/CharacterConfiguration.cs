using BiteFightRevival.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiteFightRevival.Infrastructure.Configurations;

public class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.ToTable("Characters");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Race).IsRequired();
        builder.Property(c => c.Level).IsRequired().HasDefaultValue(1);
        builder.Property(c => c.Experience).IsRequired().HasDefaultValue(0);
        builder.Property(c => c.Gold).IsRequired().HasDefaultValue(0);
        builder.Property(c => c.Hellstones).IsRequired().HasDefaultValue(0);
        builder.Property(c => c.Strength).IsRequired().HasDefaultValue(10);
        builder.Property(c => c.Defense).IsRequired().HasDefaultValue(10);
        builder.Property(c => c.Dexterity).IsRequired().HasDefaultValue(10);
        builder.Property(c => c.Endurance).IsRequired().HasDefaultValue(10);
        builder.Property(c => c.Charisma).IsRequired().HasDefaultValue(10);
        builder.Property(c => c.CurrentHealth).IsRequired().HasDefaultValue(100);
        builder.Property(c => c.MaxHealth).IsRequired().HasDefaultValue(100);
        builder.Property(c => c.ActionPoints).IsRequired().HasDefaultValue(5);
        
        builder.HasOne(c => c.Clan)
            .WithMany(c => c.Characters)
            .HasForeignKey(f => f.ClanId);
        
        builder.HasMany(c => c.Inventory)
            .WithOne(i => i.Character)
            .HasForeignKey(i => i.CharacterId);
    }
}