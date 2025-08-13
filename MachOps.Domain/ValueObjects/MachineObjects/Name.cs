using MachOps.Domain.ValueObjects.Base;
using MachOps.Domain.ValueObjects.Validations;

namespace MachOps.Domain.ValueObjects.Machines;

public sealed class Name : ValueObject
{
    public string Value { get; } = null!;
    public Name(string name)
    {
        DomainException.ThrowIfFalse(!string.IsNullOrWhiteSpace(name), "Name não pode ser nulo nem vazio.");
        Value = name;
    }

    private Name() { }
}