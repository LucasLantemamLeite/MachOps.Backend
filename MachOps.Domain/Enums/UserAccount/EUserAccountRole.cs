namespace MachOps.Domain.Enums.UserAccount;

[Flags]
public enum EUserAccountRole
{
    User = 1 << 0,
    Admin = 1 << 1
}