using MachOps.Domain.Enums;
using MachOps.Domain.Validations;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machinery;

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