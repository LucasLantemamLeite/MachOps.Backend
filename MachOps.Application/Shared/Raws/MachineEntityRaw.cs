namespace MachOps.Application.Shared.Raws;

public sealed class MachineEntityRaw
{
    public int Id { get; }
    public string Name { get; } = null!;
    public int MachType { get; }
    public int Status { get; }
    public string? Location { get; }
    public DateTime CreateAt { get; }
    public DateTime UpdateAt { get; }
    public string? Description { get; }
    public DateTime? MaintenceStartDate { get; }
    public DateTime? ExpectedReturnDate { get; }

    public MachineEntityRaw(int id, string name, int machType, int status, string? location, DateTime createAt, DateTime updateAt, string? description, DateTime? maintenceStartDate, DateTime? expectedReturnDate)
    {
        Id = id;
        Name = name;
        MachType = machType;
        Status = status;
        Location = location;
        CreateAt = createAt;
        UpdateAt = updateAt;
        Description = description;
        MaintenceStartDate = maintenceStartDate;
        ExpectedReturnDate = expectedReturnDate;
    }
}