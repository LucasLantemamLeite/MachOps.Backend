using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machinery;

public sealed class MaintenanceReturn : ValueObject
{
    public DateTime? Value { get; } = null;

    public MaintenanceReturn(DateTime? expected) => Value = expected;

    private MaintenanceReturn() { }
}