namespace MachOps.Application.Shared.Commands;

public sealed class CreateMachineryCommand(string name, int machType, int status, string? location, string? description, DateTime? maintenanceStartDate, DateTime? expectedReturn)
{
    public string MachineryName { get; init; } = name;
    public int MachineryType { get; init; } = machType;
    public int MachineryStatus { get; init; } = status;
    public string? MachineryLocation { get; init; } = location;
    public string? MachineryDescription { get; init; } = description;
    public DateTime? MaintenanceStartDate { get; init; } = maintenanceStartDate;
    public DateTime? ExpectedReturnDate { get; init; } = expectedReturn;
}