using System.Data;
using Dapper;
using MachOps.Application.Interfaces.Repositories;
using MachOps.Domain.Entities;

namespace MachOps.Infrastructure.Implementations.Repositories;

public sealed class MachineryRepository : IMachineryRepository
{
    private readonly IDbConnection _connection;

    public MachineryRepository(IDbConnection connection) => _connection = connection;

    public async Task<int> CreateAsync(Machinery machine)
    {
        var sql = @"INSERT INTO [Machines] 
        (Name, MachType, Status, Location, CreateAt, UpdateAt, Description, MaintenanceStartDate, ExpectedReturnDate)
        VALUES
        (@Name, @MachType, @Status, @Location, @CreateAt, @UpdateAt, @Description, @MaintenanceStartDate, @ExpectedReturnDate)
        SELECT CAST(SCOPE_IDENTITY() AS INT);";

        var parameters = new
        {
            Name = machine.MachineryName.Value,
            MachType = machine.MachineryType.Value,
            Status = machine.MachineryStatus.Value,
            Location = machine.MachineryLocation.Value,
            CreatedAt = machine.MachineryCreatedAt.Value,
            UpdatedAt = machine.MachineryLastUpdatedAt.Value,
            Description = machine.MachineryDescription.Value,
            MaintenanceStartDate = machine.MaintenanceStartDate.Value,
            ExpectedReturnDate = machine.ExpectedReturnDate.Value
        };

        var id = await _connection.ExecuteScalarAsync<int>(sql, parameters);

        return id;
    }

    public async Task<int> DeleteAsync(Machinery machine)
    {
        var sql = @"DELETE FROM [Machines] WHERE Id = @Id";
        var parameters = new { machine.Id };

        return await _connection.ExecuteAsync(sql, parameters);
    }

    public async Task<int> UpdateAsync(Machinery machine)
    {
        var sql = @"UPDATE [Machines] SET Name = @Name, MachType = @MachType, Location = @Location, CreateAt = @CreateAt, UpdateAt = @UpdateAt, Description = @Description, MaintenanceStartDate = @MaintenanceStartDate WHERE Id = @Id";

        var parameters = new
        {
            machine.Id,
            Name = machine.MachineryName.Value,
            MachType = machine.MachineryType.Value,
            Status = machine.MachineryStatus.Value,
            Location = machine.MachineryLocation.Value,
            CreateAt = machine.MachineryCreatedAt.Value,
            UpdateAt = machine.MachineryLastUpdatedAt.Value,
            Description = machine.MachineryDescription.Value,
            MaintenanceStartDate = machine.MaintenanceStartDate.Value,
            ExpectedReturnDate = machine.ExpectedReturnDate.Value
        };

        return await _connection.ExecuteAsync(sql, parameters);
    }
}