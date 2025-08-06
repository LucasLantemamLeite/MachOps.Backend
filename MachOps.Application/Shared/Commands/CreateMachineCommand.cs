namespace MachOps.Application.Shared.Commands;

public sealed class CreateMachineCommand
{
    public string Name { get; init; } = null!;
    public int MachType { get; init; }
    public int Status { get; init; }
    public string? Location { get; init; }
    public string? Description { get; init; }
    public DateTime? MaintenceStartDate { get; init; }
    public DateTime? ExpectedReturnDate { get; init; }

    public CreateMachineCommand(string name, int machType, string? location, int status, string? description, DateTime? maintenceStart, DateTime? expectedReturn)
    {
        Name = name;
        MachType = machType;
        Status = status;
        Location = location;
        Description = description;
        MaintenceStartDate = maintenceStart;
        ExpectedReturnDate = expectedReturn;
    }
}