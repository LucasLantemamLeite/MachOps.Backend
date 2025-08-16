using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machinery;

public sealed class MaintenanceStart : ValueObject
{
    public DateTime? Value { get; }

    public MaintenanceStart(DateTime? start) => Value = start;

    private MaintenanceStart() { }
}