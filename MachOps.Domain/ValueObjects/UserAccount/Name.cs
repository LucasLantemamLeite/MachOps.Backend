using MachOps.Domain.Validations;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.UserAccount;

public sealed class Name : ValueObject
{
    public string Value { get; } = null!;

    public Name(string name)
    {
        DomainException.ThrowIfFalse(!string.IsNullOrWhiteSpace(name), "Nome do usuário não pode ser nulo nem vazio.");
        Value = name;
    }

    private Name() { }
}