using MachOps.Domain.Enums.Machines;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machines;

public sealed class MachType : ValueObject
{
    public EMachType Value { get; }

    public MachType(int machType)
    {
        Value = (EMachType)machType;
    }

    public MachType() { }
}