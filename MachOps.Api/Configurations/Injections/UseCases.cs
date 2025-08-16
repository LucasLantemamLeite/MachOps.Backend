using MachOps.Application.Interfaces.UseCases.Users;
using MachOps.Application.Shared.UseCases.Users;

namespace MachOps.Api.Configurations.Injections;

public static class UseCasesInjection
{
    public static IServiceCollection RegisterUseCases(this IServiceCollection service)
    {
        service.AddScoped<ICreateUserAccountUseCase, CreateUserAccountUseCase>();

        return service;
    }
}