using MachOps.Domain.Enums.Machines;
using MachOps.Domain.ValueObjects.Base;
using MachOps.Domain.ValueObjects.Validations;

namespace MachOps.Domain.ValueObjects.Machines;

public sealed class Status : ValueObject
{
    public EStatus Value { get; }

    public Status(int status)
    {
        EnumException.ThrowIfNotDefined<EStatus>(status, "Status inválido.");
        Value = (EStatus)status;
    }

    public Status() { }
}