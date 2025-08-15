using MachOps.Domain.Entities.Base;
using MachOps.Domain.ValueObjects.Machinery;

namespace MachOps.Domain.Entities;

public sealed class Machinery : Entity
{
    public MachineryName Name { get; private set; }
    public MachineryType MachType { get; private set; }
    public MachineryStatus Status { get; private set; }
    public MachineryLocation Location { get; private set; }
    public MachineryCreatedAt CreateAt { get; private set; }
    public MachineryLastUpdatedAt UpdateAt { get; private set; }
    public MachineryDescription Description { get; private set; }
    public MaintenanceStartDate MaintenanceStartDate { get; private set; }
    public ExpectedReturnDate ExpectedReturnDate { get; private set; }

    public void ChangeId(int id) => Id = id;

    public Machinery(string name, int machType, string? location, int status, string? description, DateTime? maintenanceStart, DateTime? expectedReturn)
    {
        Name = new MachineryName(name);
        MachType = new MachineryType(machType);
        Status = new MachineryStatus(status);
        Location = new MachineryLocation(location);
        CreateAt = new MachineryCreatedAt();
        UpdateAt = new MachineryLastUpdatedAt();
        Description = new MachineryDescription(description);
        MaintenanceStartDate = new MaintenanceStartDate(maintenanceStart);
        ExpectedReturnDate = new ExpectedReturnDate(expectedReturn);
    }

    public Machinery(int id, string name, int machType, int status, string? location, DateTime create, DateTime update, string? description, DateTime? maintenanceStart, DateTime? expectedReturn) : base(id)
    {
        Name = new MachineryName(name);
        MachType = new MachineryType(machType);
        Status = new MachineryStatus(status);
        Location = new MachineryLocation(location);
        CreateAt = new MachineryCreatedAt(create);
        UpdateAt = new MachineryLastUpdatedAt(update);
        Description = new MachineryDescription(description);
        MaintenanceStartDate = new MaintenanceStartDate(maintenanceStart);
        ExpectedReturnDate = new ExpectedReturnDate(expectedReturn);
    }

    private Machinery() { }
}