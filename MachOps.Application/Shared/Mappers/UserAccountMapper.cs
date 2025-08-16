using MachOps.Application.Shared.Raws;
using MachOps.Domain.Entities;

namespace MachOps.Application.Shared.Mappers;

public static class UserAccountMapper
{
    public static UserAccount ToSingleUserAccount(this UserAccountRaw userRaw)
    {
        return new UserAccount
        (
        userRaw.Id,
        userRaw.Name,
        userRaw.Email,
        userRaw.Password,
        userRaw.Phone,
        userRaw.CreatedAt,
        userRaw.Active,
        userRaw.Role
        );
    }

    public static List<UserAccount> ToListUserAccount(this IEnumerable<UserAccountRaw> usersRaw) => usersRaw.Select(u => u.ToSingleUserAccount()).ToList();

    public static UserAccountRaw ToSingleUserAccountRaw(this UserAccount user)
    {
        return new UserAccountRaw
        (
            user.Id,
            user.Name.Value,
            user.Email.Value,
            user.Password.Value,
            user.Phone.Value,
            user.CreatedAt.Value,
            user.Active.Value,
            (int)user.Role.Value
        );
    }

    public static List<UserAccountRaw> ToListUserAccountRaw(this IEnumerable<UserAccount> users) => users.Select(u => u.ToSingleUserAccountRaw()).ToList();
}