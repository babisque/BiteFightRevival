using BiteFightRevival.Domain.Common;

namespace BiteFightRevival.Domain.Entities;

public class BattleReport : BaseEntity
{
    public Guid AttackerId { get; set; }
    public Guid DefenderId { get; set; }
    public Guid WinnerId { get; set; }
    public string BattleLog { get; set; }
    public long GoldStolen { get; set; }
    public int ExpGained { get; set; }
}