namespace MachOps.Domain.Enums;

[Flags]
public enum ERole
{
    Operator = 1 << 0,
    Manager = Operator | 1 << 1,
    Coordinator = Operator | Manager | 1 << 2,
    Director = Operator | Manager | Coordinator | 1 << 3,
    Admin = Operator | Manager | Coordinator | Director | 1 << 4,
    SuperAdmin = Operator | Manager | Coordinator | Director | Admin | 1 << 5
}