using BiteFightRevival.Domain.Common;

namespace BiteFightRevival.Domain.Entities;

public class InventoryItem : BaseEntity
{
    public Guid CharacterId { get; set; }
    public Guid ItemId { get; set; }
    public Item Item { get; set; }
    public bool IsEquipped { get; set; }
}