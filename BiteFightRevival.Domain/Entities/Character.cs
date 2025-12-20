using BiteFightRevival.Domain.Common;
using BiteFightRevival.Domain.Enums;

namespace BiteFightRevival.Domain.Entities;

public class Character : BaseEntity
{
    public string Name { get; set; }
    public Race Race { get; set; }
    public int Level { get; set; } = 1;
    public long Experience { get; set; } = 0;
    public long Gold { get; set; } = 0;
    public int Hellstones { get; set; } = 0;

    public int Strength { get; set; } = 10;
    public int Defense { get; set; } = 10;
    public int Dexterity { get; set; } = 10;
    public int Endurance { get; set; } = 10;
    public int Charisma { get; set; } = 10;
    
    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }
    public int ActionPoints { get; set; }
    
    public Guid UserId { get; set; }
    public Guid? ClanId { get; set; }
    public Clan Clan { get; set; }
    public ICollection<InventoryItem> Inventory { get; set; }
}