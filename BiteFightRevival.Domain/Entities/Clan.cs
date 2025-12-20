using BiteFightRevival.Domain.Common;

namespace BiteFightRevival.Domain.Entities;

public class Clan : BaseEntity
{
    public string Name { get; set; }
    public string Tag { get; set; }
    public string Description { get; set; }
    public long Treasury { get; set; } = 0;
    public ICollection<Character> Characters { get; set; }
}