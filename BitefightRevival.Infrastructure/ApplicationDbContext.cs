using BiteFightRevival.Domain.Common;
using BiteFightRevival.Domain.Entities;
using BiteFightRevival.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BiteFightRevival.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    private readonly IPublisher _publisher;
    
    public DbSet<Character> Characters { get; set; }
    public DbSet<Clan> Clans { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<BattleReport> BattleReports { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEntities = ChangeTracker
            .Entries<BaseEntity>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEntities.ToList().ForEach(entity => entity.Entity.DomainEvents.ToList().Clear());

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in domainEvents)
            await _publisher.Publish(domainEvent, cancellationToken);

        return result;
    }
}