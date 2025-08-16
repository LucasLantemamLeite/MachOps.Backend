using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machinery;

public sealed class ExpectedReturnDate : ValueObject
{
    public DateTime? Value { get; } = null;

    public ExpectedReturnDate(DateTime? expected) => Value = expected;

    private ExpectedReturnDate() { }
}