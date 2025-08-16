namespace MachOps.Domain.Enums;

[Flags]
public enum ERole
{
    Operator = 1 << 0,
    Manager = 1 << 1,
    Coordinator = 1 << 2,
    Director = 1 << 3,
    Admin = 1 << 4
}