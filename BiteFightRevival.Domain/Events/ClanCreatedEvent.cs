using BiteFightRevival.Domain.Common;
using BiteFightRevival.Domain.Entities;

namespace BiteFightRevival.Domain.Events;

public class ClanCreatedEvent(Clan clan, Guid leaderId) : IDomainEvent
{
    public Clan Clan { get; }
    public Guid LeaderId { get; }
}