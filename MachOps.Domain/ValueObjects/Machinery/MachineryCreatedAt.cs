using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machinery;

public sealed class MachineryCreatedAt : ValueObject
{
    public DateTime Value { get; }

    public MachineryCreatedAt(DateTime create) => Value = create;

    public MachineryCreatedAt()
    {
        Value = DateTime.UtcNow;
    }
}