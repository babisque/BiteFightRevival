using BiteFightRevival.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiteFightRevival.Infrastructure.Configurations;

public class BattleReportConfiguration : IEntityTypeConfiguration<BattleReport>
{
    public void Configure(EntityTypeBuilder<BattleReport> builder)
    {
        builder.ToTable("BattleReports");
        builder.HasKey(b => b.Id);

        builder.Property(b => b.BattleLog)
            .IsRequired();
        
        builder.Property(b => b.GoldStolen).IsRequired();
        builder.Property(b => b.ExpGained).IsRequired();
        
        builder.HasOne<Character>()
            .WithMany()
            .HasForeignKey(b => b.AttackerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne<Character>()
            .WithMany()
            .HasForeignKey(b => b.DefenderId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne<Character>()
            .WithMany()
            .HasForeignKey(b => b.WinnerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}