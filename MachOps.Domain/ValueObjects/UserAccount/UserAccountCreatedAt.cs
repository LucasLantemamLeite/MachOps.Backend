using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.UserAccount;

public sealed class UserAccountCreatedAt : ValueObject
{
    public DateTime Value { get; }

    public UserAccountCreatedAt() => Value = DateTime.UtcNow;

    public UserAccountCreatedAt(DateTime create) => Value = create;
}
