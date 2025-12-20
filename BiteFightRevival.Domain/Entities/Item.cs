using BiteFightRevival.Domain.Common;
using BiteFightRevival.Domain.Enums;

namespace BiteFightRevival.Domain.Entities;

public class Item : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public ItemType Type { get; set; } 
    
    public int BonusStrength { get; set; }
    public int BonusDefense { get; set; }
    public int MinLevelRequired { get; set; }
}