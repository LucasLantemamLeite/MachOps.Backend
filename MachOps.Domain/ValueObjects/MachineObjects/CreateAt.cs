using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machines;

public sealed class CreateAt : ValueObject
{
    public DateTime Value { get; }

    public CreateAt(DateTime create)
    {
        Value = create;
    }

    public CreateAt()
    {
        Value = DateTime.UtcNow;
    }
}