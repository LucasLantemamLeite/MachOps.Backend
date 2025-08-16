using MachOps.Domain.Entities.Base;
using MachOps.Domain.ValueObjects.Machinery;

namespace MachOps.Domain.Entities;

public sealed class Machinery : Entity
{
    public MachineryName MachineryName { get; private set; }
    public MachineryType MachineryType { get; private set; }
    public MachineryStatus MachineryStatus { get; private set; }
    public MachineryLocation MachineryLocation { get; private set; }
    public MachineryCreatedAt MachineryCreatedAt { get; private set; }
    public MachineryLastUpdatedAt MachineryLastUpdatedAt { get; private set; }
    public MachineryDescription MachineryDescription { get; private set; }
    public MaintenanceStartDate MaintenanceStartDate { get; private set; }
    public ExpectedReturnDate ExpectedReturnDate { get; private set; }

    public void ChangeId(int id) => Id = id;

    public Machinery(string name, int machType, string? location, int status, string? description, DateTime? maintenanceStart, DateTime? expectedReturn)
    {
        MachineryName = new MachineryName(name);
        MachineryType = new MachineryType(machType);
        MachineryStatus = new MachineryStatus(status);
        MachineryLocation = new MachineryLocation(location);
        MachineryCreatedAt = new MachineryCreatedAt();
        MachineryLastUpdatedAt = new MachineryLastUpdatedAt();
        MachineryDescription = new MachineryDescription(description);
        MaintenanceStartDate = new MaintenanceStartDate(maintenanceStart);
        ExpectedReturnDate = new ExpectedReturnDate(expectedReturn);
    }

    public Machinery(int id, string name, int machType, int status, string? location, DateTime createdAt, DateTime updatedAt, string? description, DateTime? maintenanceStart, DateTime? expectedReturn) : base(id)
    {
        MachineryName = new MachineryName(name);
        MachineryType = new MachineryType(machType);
        MachineryStatus = new MachineryStatus(status);
        MachineryLocation = new MachineryLocation(location);
        MachineryCreatedAt = new MachineryCreatedAt(createdAt);
        MachineryLastUpdatedAt = new MachineryLastUpdatedAt(updatedAt);
        MachineryDescription = new MachineryDescription(description);
        MaintenanceStartDate = new MaintenanceStartDate(maintenanceStart);
        ExpectedReturnDate = new ExpectedReturnDate(expectedReturn);
    }

    private Machinery() { }
}