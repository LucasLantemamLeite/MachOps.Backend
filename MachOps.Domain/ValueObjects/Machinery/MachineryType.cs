using MachOps.Domain.Enums.Machinery;
using MachOps.Domain.ValueObjects.Base;
using MachOps.Domain.ValueObjects.Validations;

namespace MachOps.Domain.ValueObjects.Machinery;

public sealed class MachineryType : ValueObject
{
    public EMachineryType Value { get; }

    public MachineryType(int machType)
    {
        EnumException.ThrowIfNotDefined<EMachineryType>(machType, "MachType inválido.");
        Value = (EMachineryType)machType;
    }

    private MachineryType() { }
}