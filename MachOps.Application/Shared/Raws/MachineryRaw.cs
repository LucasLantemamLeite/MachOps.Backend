namespace MachOps.Application.Shared.Raws;

public sealed class MachineryRaw(int id, string name, int machType, int status, string? location, DateTime createdAt, DateTime updatedAt, string? description, DateTime? startDate, DateTime? returnDate)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
    public int MachType { get; } = machType;
    public int Status { get; } = status;
    public string? Location { get; } = location;
    public DateTime CreatedAt { get; } = createdAt;
    public DateTime LastUpdatedAt { get; } = updatedAt;
    public string? Description { get; } = description;
    public DateTime? Start { get; } = startDate;
    public DateTime? Return { get; } = returnDate;
}