using MachOps.Api.Orchestration.Handlers.Users;
using MachOps.Application.Interfaces.Handlers.Users;

namespace MachOps.Api.Configurations.Injections;

public static class HandlerInjection
{
    public static IServiceCollection RegisterHandlers(this IServiceCollection service)
    {
        service.AddScoped<ICreateUserAccountHandler, CreateUserAccountHandler>();

        return service;
    }
}