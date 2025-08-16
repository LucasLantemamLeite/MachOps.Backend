using System.Data;
using Dapper;
using MachOps.Application.Interfaces.Queries;
using MachOps.Application.Shared.Mappers;
using MachOps.Application.Shared.Raws;
using MachOps.Domain.Entities;

namespace MachOps.Infrastructure.Implementations.Queries;

public sealed class MachineryQuery(IDbConnection connection) : IMachineryQuery
{
    private readonly IDbConnection _connection = connection;
    private const string SqlSelectBase = "SELECT Id, Name, MachType, Status, Location, CreateAt, UpdateAt, Description, MaintenanceStartDate, ExpectedReturnDate FROM [Machines]";

    public async Task<List<Machinery>> GetAllAsync()
    {
        var sql = $"{SqlSelectBase}";
        var raws = await _connection.QueryAsync<MachineryRaw>(sql, null);
        return raws.ToListMachinery();
    }

    public async Task<Machinery?> GetByIdAsync(int id)
    {
        var sql = $"{SqlSelectBase} WHERE Id = @Id";
        var parameters = new { Id = id };
        var raw = await _connection.QuerySingleOrDefaultAsync<MachineryRaw>(sql, parameters);

        return raw?.ToSingleMachinery();
    }

    public async Task<List<Machinery>> GetByIntervalAsync(DateTime maintenanceStart, DateTime expectReturn)
    {
        var start = maintenanceStart.Date;
        var end = expectReturn.Date.AddDays(1);

        var sql = $"{SqlSelectBase} WHERE MaintenceStartDate >= @Start AND ExpectedReturnDate < @End";
        var parameters = new { Start = start, End = end };
        var raws = await _connection.QueryAsync<MachineryRaw>(sql, parameters);

        return raws.ToListMachinery();
    }

    public async Task<List<Machinery>> GetByMaintenceStartDateAsync(DateTime maintenanceStart)
    {
        var start = maintenanceStart.Date;

        var sql = $"{SqlSelectBase} WHERE MaintenceStartDate = @Start";
        var parameters = new { Start = start };
        var raws = await _connection.QueryAsync<MachineryRaw>(sql, parameters);

        return raws.ToListMachinery();
    }

    public async Task<List<Machinery>> GetByExpectedReturnDateAsync(DateTime expectReturn)
    {
        var end = expectReturn.Date;

        var sql = $"{SqlSelectBase} WHERE ExpectedReturnDate = @End";
        var parameters = new { End = end };
        var raws = await _connection.QueryAsync<MachineryRaw>(sql, parameters);

        return raws.ToListMachinery();
    }

    public async Task<List<Machinery>> GetByTypeAsync(int type)
    {
        var sql = $"{SqlSelectBase} WHERE MachType = @MachType";
        var parameters = new { MachType = type };
        var raws = await _connection.QueryAsync<MachineryRaw>(sql, parameters);

        return raws.ToListMachinery();
    }

    public async Task<Machinery?> GetByNameAsync(string name)
    {
        var sql = $"{SqlSelectBase} WHERE Name = @Name";
        var parameters = new { Name = name };
        var raw = await _connection.QuerySingleOrDefaultAsync<MachineryRaw>(sql, parameters);

        return raw?.ToSingleMachinery();
    }

    public async Task<List<Machinery>> GetByStatusAsync(int status)
    {
        var sql = $"{SqlSelectBase} WHERE Status = @Status";
        var parameters = new { Status = status };
        var raws = await _connection.QueryAsync<MachineryRaw>(sql, parameters);

        return raws.ToListMachinery();
    }
}