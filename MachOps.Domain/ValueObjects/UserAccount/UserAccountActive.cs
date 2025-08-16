using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.UserAccount;

public sealed class UserAccountActive : ValueObject
{
    public bool Value { get; } = true;

    public UserAccountActive() { }

    public UserAccountActive(bool active) => Value = active;
}