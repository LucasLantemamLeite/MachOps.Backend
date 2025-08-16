using MachOps.Domain.Validations;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.UserAccount;

public sealed class Email : ValueObject
{
    public string Value { get; } = null!;

    public Email(string email)
    {
        EmailRegexException.ThrowIfNotMatch(email, "Email inválido.");
        Value = email;
    }
}