namespace AnglingCompanion.Models.Base;

public abstract class Resource
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}