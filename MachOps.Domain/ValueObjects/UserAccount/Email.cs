using MachOps.Domain.Validations;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.UserAccount;

public sealed class UserAccountEmail : ValueObject
{
    public string Value { get; } = null!;

    public UserAccountEmail(string email)
    {
        EmailRegexException.ThrowIfNotMatch(email, "Email inválido.");
        Value = email;
    }
}