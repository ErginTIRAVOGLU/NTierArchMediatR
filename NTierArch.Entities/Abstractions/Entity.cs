namespace NTierArch.Entities.Abstractions;
public abstract class Entity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid CreatedById { get; set; }
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public bool IsHidden { get; set; } = false;
    public Guid? UpdatedById { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
    public Guid? DeletedById { get; set; }
    public DateTime? DeletedDate { get; set; }
}
