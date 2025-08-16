using MachOps.Application.Interfaces.Queries;
using MachOps.Application.Shared.UseCases.Base.Utils;
using MachOps.Infrastructure.Implementations.Queries;

namespace MachOps.Api.Configurations.Injections;

public static class QueryInjection
{
    public static IServiceCollection RegisterQueries(this IServiceCollection service)
    {
        service.AddScoped<IUserAccountQuery, UserAccountQuery>();
        service.AddScoped<IMachineryQuery, MachineryQuery>();

        service.AddScoped(sp => new Queries(
            sp.GetRequiredService<IUserAccountQuery>(),
            sp.GetRequiredService<IMachineryQuery>()
        ));

        return service;
    }
}