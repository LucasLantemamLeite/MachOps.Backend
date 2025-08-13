using System.Data;
using Dapper;
using MachOps.Application.Interfaces.Repositories;
using MachOps.Domain.Entities;

namespace MachOps.Infrastructure.Implementations.Repositories;

public sealed class MachineRepository : IMachineRepository
{
    private readonly IDbConnection _connection;

    public MachineRepository(IDbConnection connection) => _connection = connection;

    public async Task<int> CreateAsync(MachineEntity machine)
    {
        var sql = @"INSERT INTO [Machines] 
        (Name, MachType, Status, Location, CreateAt, UpdateAt, Description, MaintenanceStartDate, ExpectedReturnDate)
        VALUES
        (@Name, @MachType, @Status, @Location, @CreateAt, @UpdateAt, @Description, @MaintenanceStartDate, @ExpectedReturnDate)
        SELECT CAST(SCOPE_IDENTITY() AS INT);";

        var parameters = new
        {
            Name = machine.Name.Value,
            MachType = machine.MachType.Value,
            Status = machine.Status.Value,
            Location = machine.Location.Value,
            CreateAt = machine.CreateAt.Value,
            UpdateAt = machine.UpdateAt.Value,
            Description = machine.Description.Value,
            MaintenanceStartDate = machine.MaintenanceStartDate.Value,
            ExpectedReturnDate = machine.ExpectedReturnDate.Value
        };

        var id = await _connection.ExecuteScalarAsync<int>(sql, parameters);

        return id;
    }

    public async Task<int> DeleteAsync(MachineEntity machine)
    {
        var sql = @"DELETE FROM [Machines] WHERE Id = @Id";
        var parameters = new { machine.Id };

        return await _connection.ExecuteAsync(sql, parameters);
    }

    public async Task<int> UpdateAsync(MachineEntity machine)
    {
        var sql = @"UPDATE [Machines] SET Name = @Name, MachType = @MachType, Location = @Location, CreateAt = @CreateAt, UpdateAt = @UpdateAt, Description = @Description, MaintenanceStartDate = @MaintenanceStartDate WHERE Id = @Id";

        var parameters = new
        {
            machine.Id,
            Name = machine.Name.Value,
            MachType = machine.MachType.Value,
            Status = machine.Status.Value,
            Location = machine.Location.Value,
            CreateAt = machine.CreateAt.Value,
            UpdateAt = machine.UpdateAt.Value,
            Description = machine.Description.Value,
            MaintenanceStartDate = machine.MaintenanceStartDate.Value,
            ExpectedReturnDate = machine.ExpectedReturnDate.Value
        };

        return await _connection.ExecuteAsync(sql, parameters);
    }
}