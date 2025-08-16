namespace MachOps.Application.Shared.Raws;

public sealed class MachineryRaw(int id, string name, int machType, int status, string? location, DateTime createdAt, DateTime updatedAt, string? description, DateTime? maintenanceStartDate, DateTime? expectedReturnDate)
{
    public int Id { get; } = id;
    public string MachineryName { get; } = name;
    public int MachineryType { get; } = machType;
    public int MachineryStatus { get; } = status;
    public string? MachineryLocation { get; } = location;
    public DateTime MachineryCreatedAt { get; } = createdAt;
    public DateTime MachineryLastUpdatedAt { get; } = updatedAt;
    public string? MachineryDescription { get; } = description;
    public DateTime? MaintenanceStartDate { get; } = maintenanceStartDate;
    public DateTime? ExpectedReturnDate { get; } = expectedReturnDate;
}