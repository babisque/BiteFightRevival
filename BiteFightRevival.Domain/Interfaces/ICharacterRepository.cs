using BiteFightRevival.Domain.Entities;

namespace BiteFightRevival.Domain.Interfaces;

public interface ICharacterRepository
{
    Task<Character?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Character?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    Task UpdateAsync(Character character, CancellationToken cancellationToken);
}