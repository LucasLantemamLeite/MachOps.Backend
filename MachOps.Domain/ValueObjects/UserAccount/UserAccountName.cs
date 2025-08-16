using MachOps.Domain.Validations;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.UserAccount;

public sealed class UserAccountName : ValueObject
{
    public string Value { get; } = null!;

    public UserAccountName(string name)
    {
        DomainException.ThrowIfFalse(!string.IsNullOrWhiteSpace(name), "Nome do usuário não pode ser vazio ou nulo.");
        Value = name;
    }
}