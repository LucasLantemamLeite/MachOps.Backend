using MachOps.Application.Interfaces.Repositories;
using MachOps.Application.Shared.UseCases.Base.Utils;
using MachOps.Infrastructure.Implementations.Repositories;

namespace MachOps.Api.Configurations.Injections;

public static class RepositoryInjection
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection service)
    {
        service.AddScoped<IUserAccountRepository, UserAccountRepository>();
        service.AddScoped<IMachineryRepository, MachineryRepository>();

        service.AddScoped(sp => new Repositories(
            sp.GetRequiredService<IUserAccountRepository>(),
            sp.GetRequiredService<IMachineryRepository>()
        ));

        return service;
    }
}