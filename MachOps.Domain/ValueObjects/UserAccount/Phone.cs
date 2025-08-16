using MachOps.Domain.Validations;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.UserAccount;

public sealed class Phone : ValueObject
{
    public string Value { get; } = null!;

    public Phone(string phone)
    {
        PhoneRegexException.ThrowIfNotMatch(phone, "Phone inválido.");
        Value = phone;
    }

    private Phone() { }
}