namespace MachOps.Application.Shared.Commands;

public sealed class CreateUserAccountCommand(string name, string email, string password, string phone, string role)
{
    public string Name { get; init; } = name;
    public string Email { get; init; } = email;
    public string Password { get; init; } = password;
    public string Phone { get; init; } = phone;
    public string Role { get; init; } = role;
}