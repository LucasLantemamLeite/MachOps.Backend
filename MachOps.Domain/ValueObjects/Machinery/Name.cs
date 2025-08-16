using MachOps.Domain.Validations;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machinery;

public sealed class Name : ValueObject
{
    public string Value { get; } = null!;
    public Name(string name)
    {
        DomainException.ThrowIfFalse(!string.IsNullOrWhiteSpace(name), "Nome da máquina não pode ser nulo nem vazio.");
        Value = name;
    }

    private Name() { }
}