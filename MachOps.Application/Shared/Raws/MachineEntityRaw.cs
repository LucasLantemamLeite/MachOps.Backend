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
    public DateTime MaintenceStartDate { get; }
    public DateTime ExpectedReturnDate { get; }
}