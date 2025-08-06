using MachOps.Domain.Entities.Base;
using MachOps.Domain.ValueObjects.Machines;

namespace MachOps.Domain.Entities;

public sealed class MachineEntity : Entity
{
    public Name Name { get; private set; }
    public MachType MachType { get; private set; }
    public Status Status { get; private set; }
    public Location Location { get; private set; }
    public CreateAt CreateAt { get; private set; }
    public UpdateAt UpdateAt { get; private set; }
    public Description Description { get; private set; }
    public MaintenceStartDate MaintenceStartDate { get; private set; }
    public ExpectedReturnDate ExpectedReturnDate { get; private set; }

    public MachineEntity(string name, int machType, string? location, int status, string? description, DateTime? maintenceStart, DateTime? expectedReturn)
    {
        Name = new Name(name);
        MachType = new MachType(machType);
        Status = new Status(status);
        Location = new Location(location);
        CreateAt = new CreateAt();
        UpdateAt = new UpdateAt();
        Description = new Description(description);
        MaintenceStartDate = new MaintenceStartDate(maintenceStart);
        ExpectedReturnDate = new ExpectedReturnDate(expectedReturn);
    }

    public MachineEntity(int id, string name, int machType, int status, string? location, DateTime create, DateTime update, string? description, DateTime? maintenceStart, DateTime? expectedReturn) : base(id)
    {
        Name = new Name(name);
        MachType = new MachType(machType);
        Status = new Status(status);
        Location = new Location(location);
        CreateAt = new CreateAt(create);
        UpdateAt = new UpdateAt(update);
        Description = new Description(description);
        MaintenceStartDate = new MaintenceStartDate(maintenceStart);
        ExpectedReturnDate = new ExpectedReturnDate(expectedReturn);
    }

    private MachineEntity() { }
}