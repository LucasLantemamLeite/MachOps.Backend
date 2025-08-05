using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machines;

public sealed class MaintenceStartDate : ValueObject
{
    public DateTime? Value { get; }

    public MaintenceStartDate(DateTime? start) => Value = start ?? DateTime.UtcNow;

    private MaintenceStartDate() { }
}