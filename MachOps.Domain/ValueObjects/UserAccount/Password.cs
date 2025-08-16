using MachOps.Domain.Validations;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.UserAccount;

public sealed class Password : ValueObject
{
    public string Value { get; } = null!;

    public Password(string password)
    {
        DomainException.ThrowIfFalse(!string.IsNullOrWhiteSpace(password), "Senha do usuário não pode ser nulo nem vazio.");
        Value = password;
    }

    private Password() { }
}