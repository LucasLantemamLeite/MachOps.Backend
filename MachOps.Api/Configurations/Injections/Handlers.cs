using MachOps.Api.Orchestrations.Handlers;
using MachOps.Application.Interfaces.Handlers;

namespace MachOps.Api.Configurations.Injections;

public static class HandlerInjection
{
    public static IServiceCollection RegisterHandlers(this IServiceCollection service)
    {
        service.AddScoped<ICreateMachineHandler, CreateMachineHandler>();

        return service;
    }
}