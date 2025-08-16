using System.Data;
using Dapper;
using MachOps.Application.Interfaces.Repositories;
using MachOps.Domain.Entities;

namespace MachOps.Infrastructure.Implementations.Repositories;

public sealed class UserAccountRepository(IDbConnection connection) : IUserAccountRepository
{
    private readonly IDbConnection _connection = connection;

    public async Task<int> CreateAsync(UserAccount user)
    {
        var sql = @"INSERT INTO [Users] 
        (Name, Email, Password, Phone, CreatedAt, Active, Role) 
        VALUES
        (@Name, @Email, @Password, @Phone, @CreatedAt, @Active, @Role);
        SELECT CAST(SCOPE_IDENTITY() AS INT);";

        var parameters = new
        {
            Name = user.Name.Value,
            Email = user.Email.Value,
            Password = user.Password.Value,
            Phone = user.Phone.Value,
            CreatedAt = user.CreatedAt.Value,
            Active = user.Active.Value,
            Role = user.Role.Value
        };

        var id = await _connection.ExecuteScalarAsync<int>(sql, parameters);

        return id;
    }

    public async Task<int> DisableAsync(UserAccount user)
    {
        var sql = "DELETE FROM [Users] WHERE Id = @Id";
        var parameters = new { user.Id };
        var rows = await _connection.ExecuteAsync(sql, parameters);

        return rows;
    }

    public async Task<int> UpdateAsync(UserAccount user)
    {
        var sql = @"UPDATE [Users] SET Name = @Name, Email = @Email, Password = @Password, Phone = @Phone, Active = @Active, Role = @Role WHERE Id = @Id";

        var parameters = new
        {
            user.Id,
            Name = user.Name.Value,
            Email = user.Email.Value,
            Password = user.Password.Value,
            Phone = user.Phone.Value,
            Active = user.Active.Value,
            Role = user.Role.Value
        };

        var rows = await _connection.ExecuteAsync(sql, parameters);

        return rows;
    }
}