using MachOps.Domain.Enums.UserAccount;
using MachOps.Domain.Validations.UserAccount;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.UserAccount;

public sealed class UserAccountRole : ValueObject
{
    public EUserAccountRole Value { get; }

    public UserAccountRole(int role)
    {
        EnumFlagsException.ThrowIfNotFlagDefined<EUserAccountRole>(role, "Role Inválido.");
        Value = (EUserAccountRole)role;
    }
}