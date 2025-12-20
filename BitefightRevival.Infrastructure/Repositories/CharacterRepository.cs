using BiteFightRevival.Domain.Entities;
using BiteFightRevival.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BiteFightRevival.Infrastructure.Repositories;

public class CharacterRepository(ApplicationDbContext ctx) : ICharacterRepository
{
    public async Task<Character?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await ctx.Characters.FindAsync([id], cancellationToken: cancellationToken);
    }

    public async Task<Character?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await ctx.Characters
            .FirstOrDefaultAsync(character => character.UserId == userId, cancellationToken: cancellationToken);
    }
    
    public async Task<Character?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await ctx.Characters
            .FirstOrDefaultAsync(character => character.Name == name, cancellationToken: cancellationToken);
    }
    
    public async Task CreateAsync(Character character, CancellationToken cancellationToken)
    {
        await ctx.Characters.AddAsync(character, cancellationToken);
        await ctx.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Character character, CancellationToken cancellationToken)
    {
        ctx.Characters.Update(character);
        await ctx.SaveChangesAsync(cancellationToken);
    }
}