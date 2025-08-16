using MachOps.Domain.Entities.Base;
using MachOps.Domain.ValueObjects.Generics;
using MachOps.Domain.ValueObjects.Machinery;

namespace MachOps.Domain.Entities;

public sealed class Machinery : Entity
{
    public Name Name { get; private set; }
    public MachType MachType { get; private set; }
    public Status Status { get; private set; }
    public Location Location { get; private set; }
    public CreatedAt CreatedAt { get; private set; }
    public LastUpdatedAt LastUpdatedAt { get; private set; }
    public Description Description { get; private set; }
    public MaintenanceStart MaintenanceStart { get; private set; }
    public MaintenanceReturn MaintenanceReturn { get; private set; }

    public void ChangeId(int id) => Id = id;

    public Machinery(string name, int machType, string? location, int status, string? description, DateTime? maintenanceStart, DateTime? expectedReturn)
    {
        Name = new Name(name);
        MachType = new MachType(machType);
        Status = new Status(status);
        Location = new Location(location);
        CreatedAt = new CreatedAt();
        LastUpdatedAt = new LastUpdatedAt();
        Description = new Description(description);
        MaintenanceStart = new MaintenanceStart(maintenanceStart);
        MaintenanceReturn = new MaintenanceReturn(expectedReturn);
    }

    public Machinery(int id, string name, int machType, int status, string? location, DateTime createdAt, DateTime updatedAt, string? description, DateTime? maintenanceStart, DateTime? expectedReturn) : base(id)
    {
        Name = new Name(name);
        MachType = new MachType(machType);
        Status = new Status(status);
        Location = new Location(location);
        CreatedAt = new CreatedAt(createdAt);
        LastUpdatedAt = new LastUpdatedAt(updatedAt);
        Description = new Description(description);
        MaintenanceStart = new MaintenanceStart(maintenanceStart);
        MaintenanceReturn = new MaintenanceReturn(expectedReturn);
    }

    private Machinery() { }
}