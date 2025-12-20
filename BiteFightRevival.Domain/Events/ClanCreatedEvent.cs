using BiteFightRevival.Domain.Common;
using BiteFightRevival.Domain.Entities;

namespace BiteFightRevival.Domain.Events;

public class ClanCreatedEvent(Clan clan, Guid leaderId) : IDomainEvent;