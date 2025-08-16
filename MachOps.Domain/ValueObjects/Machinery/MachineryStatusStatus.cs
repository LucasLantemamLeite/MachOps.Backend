using MachOps.Domain.Enums.Machinery;
using MachOps.Domain.Validations;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machinery;

public sealed class MachineryStatus : ValueObject
{
    public EMachineryStatus Value { get; }

    public MachineryStatus(int status)
    {
        EnumException.ThrowIfNotDefined<EMachineryStatus>(status, "Status inválido.");
        Value = (EMachineryStatus)status;
    }

    private MachineryStatus() { }
}