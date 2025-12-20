namespace BiteFightRevival.Domain.Common;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }
    
    public void SetUpdatedAt() => UpdatedAt = DateTime.Now;
}