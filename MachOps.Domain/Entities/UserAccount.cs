using MachOps.Domain.Entities.Base;
using MachOps.Domain.ValueObjects.Generics;
using MachOps.Domain.ValueObjects.UserAccount;

namespace MachOps.Domain.Entities;

public sealed class UserAccount : Entity
{
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public Phone Phone { get; private set; }
    public CreatedAt CreatedAt { get; private set; }
    public Active Active { get; private set; }
    public Role Role { get; private set; }

    public void ChangeId(int id) => Id = id;

    public UserAccount(string name, string email, string password, string phone, int role)
    {
        Name = new Name(name);
        Email = new Email(email);
        Password = new Password(password);
        Phone = new Phone(phone);
        CreatedAt = new CreatedAt();
        Active = new Active();
        Role = new Role(role);
    }

    public UserAccount(int id, string name, string email, string password, string phone, DateTime create, bool active, int role) : base(id)
    {
        Name = new Name(name);
        Email = new Email(email);
        Password = new Password(password);
        Phone = new Phone(phone);
        CreatedAt = new CreatedAt(create);
        Active = new Active(active);
        Role = new Role(role);
    }

    private UserAccount() { }
}