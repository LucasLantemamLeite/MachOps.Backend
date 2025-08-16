using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machinery;

public sealed class MachineryLastUpdatedAt : ValueObject
{
    public DateTime Value { get; }

    public MachineryLastUpdatedAt(DateTime update) => Value = update;

    public MachineryLastUpdatedAt()
    {
        Value = DateTime.UtcNow;
    }
}