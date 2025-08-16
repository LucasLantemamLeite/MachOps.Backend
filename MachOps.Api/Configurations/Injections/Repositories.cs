using MachOps.Application.Interfaces.Repositories;
using MachOps.Infrastructure.Implementations.Repositories;

namespace MachOps.Api.Configurations.Injections;

public static class RepositoryInjection
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection service)
    {
        service.AddScoped<IMachineryRepository, MachineryRepository>();

        return service;
    }
}