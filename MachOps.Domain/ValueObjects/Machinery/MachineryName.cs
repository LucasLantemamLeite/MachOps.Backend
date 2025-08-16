using MachOps.Domain.Validations;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machinery;

public sealed class MachineryName : ValueObject
{
    public string Value { get; } = null!;
    public MachineryName(string name)
    {
        DomainException.ThrowIfFalse(!string.IsNullOrWhiteSpace(name), "Name não pode ser nulo nem vazio.");
        Value = name;
    }

    private MachineryName() { }
}