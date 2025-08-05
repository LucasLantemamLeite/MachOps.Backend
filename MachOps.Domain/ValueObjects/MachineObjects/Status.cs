using MachOps.Domain.Enums.Machines;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machines;

public sealed class Status : ValueObject
{
    public EStatus Value { get; }

    public Status(int status)
    {
        Value = (EStatus)status;
    }

    public Status() { }
}