namespace MachOps.Domain.Entities.Base;

public abstract class Entity
{
    public int Id { get; protected set; }

    protected Entity(int id) => Id = id;

    protected Entity() { }
}