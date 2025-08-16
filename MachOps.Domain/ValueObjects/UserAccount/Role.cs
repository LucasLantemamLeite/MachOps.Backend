using MachOps.Domain.Enums;
using MachOps.Domain.Validations;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.UserAccount;

public sealed class Role : ValueObject
{
    public ERole Value { get; } = ERole.User;

    public Role(int role)
    {
        EnumFlagsException.ThrowIfNotFlagDefined<ERole>(role, "Role inválido.");
        Value = (ERole)role;
    }
}