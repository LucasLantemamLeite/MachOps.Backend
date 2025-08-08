using System.Data;
using MachOps.Application.Interfaces.UseCases;
using MachOps.Application.Shared.UseCases.Base;
using MachOps.Migrations.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MachOps.Api.Configurations.Injections;

public static class ServiceInjetion
{
    public static IServiceCollection RegisterServices(this IServiceCollection service, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        service.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        service.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));
        service.AddScoped<IUnused, Unused>();

        return service;
    }
}