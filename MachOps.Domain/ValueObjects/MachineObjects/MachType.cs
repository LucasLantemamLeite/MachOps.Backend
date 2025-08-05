using MachOps.Domain.Enums.Machines;
using MachOps.Domain.ValueObjects.Base;
using MachOps.Domain.ValueObjects.Validations;

namespace MachOps.Domain.ValueObjects.Machines;

public sealed class MachType : ValueObject
{
    public EMachType Value { get; }

    public MachType(int machType)
    {
        EnumException.ThrowIfNotDefined<EMachType>(machType, "MachType inválido.");
        Value = (EMachType)machType;
    }

    private MachType() { }
}