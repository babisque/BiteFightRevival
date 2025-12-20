using BiteFightRevival.Domain.Common;
using BiteFightRevival.Domain.Events;

namespace BiteFightRevival.Domain.Entities;

public class Clan : BaseEntity
{
    public string Name { get; set; }
    public string Tag { get; set; }
    public string Description { get; set; }
    public long Treasury { get; set; }
    public ICollection<Character> Characters { get; set; }
    public Guid LeaderId { get; set; }

    public Clan(string name, string tag, Guid leaderId)
    {
        Name = name;
        Tag = tag;
        LeaderId = leaderId;
    }

    public Clan() { }

    public static Clan Create(string name, string tag, Guid leaderId)
    {
        var clan = new Clan(name, tag, leaderId);
        
        clan.AddDomainEvent(new ClanCreatedEvent(clan, leaderId));
        
        return clan;
    }
}