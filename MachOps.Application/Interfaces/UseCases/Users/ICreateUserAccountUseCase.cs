using MachOps.Application.Shared.Commands;
using MachOps.Application.Shared.ResultCases;
using MachOps.Domain.Entities;

namespace MachOps.Application.Interfaces.UseCases.Users;

public interface ICreateUserAccountUseCase
{
    Task<Result<UserAccount>> ExecuteAsync(CreateUserAccountCommand command);
}
