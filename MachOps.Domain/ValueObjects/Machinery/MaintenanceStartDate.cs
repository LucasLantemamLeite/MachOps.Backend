using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machinery;

public sealed class MaintenanceStartDate : ValueObject
{
    public DateTime? Value { get; }

    public MaintenanceStartDate(DateTime? start) => Value = start;

    private MaintenanceStartDate() { }
}