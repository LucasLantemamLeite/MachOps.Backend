using MachOps.Domain.Enums;
using MachOps.Domain.Validations;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.UserAccount;

public sealed class UserAccountRole : ValueObject
{
    public ERole Value { get; }

    public UserAccountRole(int role)
    {
        EnumFlagsException.ThrowIfNotFlagDefined<ERole>(role, "Role inválido.");
        Value = (ERole)role;
    }
}