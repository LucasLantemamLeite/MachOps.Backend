using MachOps.Domain.Entities;

namespace MachOps.Application.Interfaces.Queries;

public interface IUserAccountQuery
{
    Task<UserAccount?> GetByIdAsync(int id);
    Task<List<UserAccount>> GetByNameAsync(string name);
    Task<UserAccount?> GetByEmailAsync(string email);
    Task<UserAccount?> GetByPhoneAsync(string phone);
    Task<List<UserAccount>> GetByActiveAsync(bool active);
    Task<List<UserAccount>> GetByRoleAsync(int role);
}