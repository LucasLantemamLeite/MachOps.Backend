using MachOps.Domain.Enums;
using MachOps.Domain.Validations;
using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machinery;

public sealed class Status : ValueObject
{
    public EStatus Value { get; }

    public Status(int status)
    {
        EnumException.ThrowIfNotDefined<EStatus>(status, "Status inválido.");
        Value = (EStatus)status;
    }

    private Status() { }
}