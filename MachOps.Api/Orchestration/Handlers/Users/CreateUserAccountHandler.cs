using MachOps.Application.Interfaces.Handlers.Users;
using MachOps.Application.Interfaces.UseCases.Users;
using MachOps.Application.Shared.Commands;
using MachOps.Application.Shared.DTOs.Users;
using MachOps.Application.Shared.ResultCases;
using MachOps.Domain.Entities;

namespace MachOps.Api.Orchestration.Handlers.Users;

public sealed class CreateUserAccountHandler(ICreateUserAccountUseCase useCase) : ICreateUserAccountHandler
{
    private readonly ICreateUserAccountUseCase _useCase = useCase;

    public async Task<Result<UserAccount>> Handle(CreateUserAccountDto userDto)
    {
        var command = new CreateUserAccountCommand(userDto.Name, userDto.Email, userDto.Password, userDto.Phone, userDto.Role);

        return await _useCase.ExecuteAsync(command);
    }
}