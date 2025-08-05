using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machines;

public sealed class MaintenceStartDate : ValueObject
{
    public DateTime? Value { get; } = null;

    public MaintenceStartDate(DateTime start)
    {
        Value = start;
    }

    public MaintenceStartDate() => Value = DateTime.UtcNow;

}