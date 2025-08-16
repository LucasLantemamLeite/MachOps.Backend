using MachOps.Application.Shared.DTOs.Users;
using MachOps.Application.Shared.ResultCases;
using MachOps.Domain.Entities;

namespace MachOps.Application.Interfaces.Handlers.Users;

public interface ICreateUserAccountHandlers
{
    Task<Result<UserAccount?>> Handle(CreateUserAccountDto userDto);
}