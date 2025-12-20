using BiteFightRevival.Domain.Events;
using BiteFightRevival.Domain.Interfaces;
using MediatR;

namespace BiteFightRevival.Application.Clans.EventHandlers;

public class ClanCreatedEventHandler(ICharacterRepository characterRepository) : INotificationHandler<ClanCreatedEvent>
{
    public async Task Handle(ClanCreatedEvent notification, CancellationToken cancellationToken)
    {
        var leader = await characterRepository.GetByUserIdAsync(notification.LeaderId, cancellationToken);

        if (leader is null) return;
        
        leader.ClanId = notification.Clan.Id;
        
        await characterRepository.UpdateAsync(leader, cancellationToken);
    }
}