using MachOps.Domain.Validations.UserAccount;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.UserAccount;

public sealed class UserAccountPhone : ValueObject
{
    public string Value { get; } = null!;

    public UserAccountPhone(string phone)
    {
        PhoneRegexException.ThrowIfNotMatch(phone, "Phone não está em formato válido.");
        Value = phone;
    }
}