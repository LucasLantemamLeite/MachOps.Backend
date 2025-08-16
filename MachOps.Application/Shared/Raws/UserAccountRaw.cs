namespace MachOps.Application.Shared.Raws;

public sealed class UserAccountRaw(int id, string name, string email, string password, string phone, DateTime create, bool active, int role)
{
    public int Id { get; init; } = id;
    public string Name { get; init; } = name;
    public string Email { get; init; } = email;
    public string Password { get; init; } = password;
    public string Phone { get; init; } = phone;
    public DateTime CreatedAt { get; init; } = create;
    public bool Active { get; init; } = active;
    public int Role { get; init; } = role;
}