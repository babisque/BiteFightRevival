using BiteFightRevival.Domain.Entities;
using BiteFightRevival.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BiteFightRevival.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public DbSet<Character> Characters { get; set; }
    public DbSet<Clan> Clans { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<BattleReport> BattleReports { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}