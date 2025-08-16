using MachOps.Domain.Validations;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.UserAccount;

public sealed class UserAccountPassword : ValueObject
{
    public string Value { get; } = null!;

    public UserAccountPassword(string password)
    {
        DomainException.ThrowIfFalse(!string.IsNullOrWhiteSpace(password), "Senha do usuário não pode ser vazio ou nulo.");
        Value = password;
    }
}