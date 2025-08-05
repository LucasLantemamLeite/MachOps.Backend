using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machines;

public sealed class UpdateAt : ValueObject
{
    public DateTime Value { get; }

    public UpdateAt(DateTime update) => Value = update;

    public UpdateAt() => Value = DateTime.UtcNow;
}