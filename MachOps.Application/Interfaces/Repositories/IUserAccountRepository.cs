using MachOps.Domain.Entities;

namespace MachOps.Application.Interfaces.Repositories;

public interface IUserAccountRepository
{
    Task<int> CreateAsync(UserAccount user);
    Task<int> DisableAsync(UserAccount user);
    Task<int> UpdateAsync(UserAccount user);
}