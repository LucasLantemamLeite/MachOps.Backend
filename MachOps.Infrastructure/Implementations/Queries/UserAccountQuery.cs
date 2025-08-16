using System.Data;
using Dapper;
using MachOps.Application.Interfaces.Queries;
using MachOps.Application.Shared.Mappers;
using MachOps.Application.Shared.Raws;
using MachOps.Domain.Entities;

namespace MachOps.Infrastructure.Implementations.Queries;

public sealed class UserAccountQuery(IDbConnection connection) : IUserAccountQuery
{
    private readonly IDbConnection _connection = connection;

    private const string SqlSelectBase = "SELECT Id, Name, Email, Password, Phone, CreatedAt, Active, Role FROM [Users]";

    public async Task<List<UserAccount>> GetByActiveAsync(bool active)
    {
        var sql = $"{SqlSelectBase} WHERE Active = @Active";
        var parameters = new { Active = active };
        var users = await _connection.QueryAsync<UserAccountRaw>(sql, parameters);

        return users.ToListUserAccount();
    }

    public async Task<UserAccount?> GetByEmailAsync(string email)
    {
        var sql = $"{SqlSelectBase} WHERE Email = @Email";
        var parameters = new { Email = email };
        var user = await _connection.QuerySingleOrDefaultAsync<UserAccountRaw>(sql, parameters);

        return user?.ToSingleUserAccount();
    }

    public async Task<UserAccount?> GetByIdAsync(int id)
    {
        var sql = $"{SqlSelectBase} WHERE Id = @Id";
        var parameters = new { Id = id };
        var user = await _connection.QuerySingleOrDefaultAsync<UserAccountRaw>(sql, parameters);

        return user?.ToSingleUserAccount();
    }

    public async Task<List<UserAccount>> GetByNameAsync(string name)
    {
        var sql = $"{SqlSelectBase} WHERE Name = @Name";
        var parameters = new { Name = name };
        var users = await _connection.QueryAsync<UserAccountRaw>(sql, parameters);

        return users.ToListUserAccount();
    }

    public async Task<UserAccount?> GetByPhoneAsync(string phone)
    {
        var sql = $"{SqlSelectBase} WHERE Phone = @Phone";
        var parameters = new { Phone = phone };
        var user = await _connection.QuerySingleOrDefaultAsync<UserAccountRaw>(sql, parameters);

        return user?.ToSingleUserAccount();
    }

    public async Task<List<UserAccount>> GetByRoleAsync(int role)
    {
        var sql = $"{SqlSelectBase} WHERE Role = @Role";
        var parameters = new { Role = role };
        var users = await _connection.QueryAsync<UserAccountRaw>(sql, parameters);

        return users.ToListUserAccount();
    }
}