using MachOps.Application.Interfaces.Queries;
using MachOps.Infrastructure.Implementations.Queries;

namespace MachOps.Api.Configurations.Injections;

public static class QueryInjection
{
    public static IServiceCollection RegisterQueries(this IServiceCollection service)
    {
        service.AddScoped<IMachineryQuery, MachineryQuery>();

        return service;
    }
}