namespace AnglingCompanion.Models.Base;

public abstract class UserResource : Resource
{
    public Guid UserId { get; set; }
}