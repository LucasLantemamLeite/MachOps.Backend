using MachOps.Application.Interfaces.UseCases;
using MachOps.Application.Shared.UseCases;

namespace MachOps.Api.Configurations.Injections;

public static class UseCasesInjection
{
    public static IServiceCollection RegisterUseCases(this IServiceCollection service)
    {
        service.AddScoped<ICreateMachineUseCase, CreateMachineUseCase>();

        return service;
    }
}