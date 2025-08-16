using MachOps.Application.Interfaces.UseCases.Users;
using MachOps.Application.Shared.Commands;
using MachOps.Application.Shared.ResultCases;
using MachOps.Application.Shared.UseCases.Base;
using MachOps.Application.Shared.UseCases.Base.Utils;
using MachOps.Domain.Entities;
using MachOps.Domain.Enums;
using MachOps.Domain.Validations;

namespace MachOps.Application.Shared.UseCases.Users;

public sealed class CreateUserAccountUseCase(Queries query, Repositories repository) : BaseUseCase<Queries, Repositories>(query, repository), ICreateUserAccountUseCase
{
    public async Task<Result<UserAccount>> ExecuteAsync(CreateUserAccountCommand command)
    {
        try
        {
            var existingEmail = await Query.UserQuery.GetByEmailAsync(command.Email);

            if (existingEmail is not null)
                return Result<UserAccount>.Fail("Email já está em uso.");

            var existingPhone = await Query.UserQuery.GetByPhoneAsync(command.Phone);

            if (existingPhone is not null)
                return Result<UserAccount>.Fail("Phone já está em uso.");

            if (!Enum.TryParse<ERole>(command.Role, out var roleAsEnum))
                return Result<UserAccount>.Fail("Role inválido.");

            var userAccount = new UserAccount(command.Name, command.Email, command.Password, command.Phone, (int)roleAsEnum);

            var id = await Repository.UserRepository.CreateAsync(userAccount);

            userAccount.ChangeId(id);

            return Result<UserAccount>.Ok($"Conta criada com sucesso.", userAccount);
        }

        catch (Exception ex) when (ex is DomainException or EnumFlagsException or EmailRegexException or PhoneRegexException)
        {
            return Result<UserAccount>.Fail(ex.InnerException?.Message ?? ex.Message ?? "Erro desconhecido.");
        }

        catch
        {
            return Result<UserAccount>.Fail("Erro interno no servidor. Tente novamente mais tarde.");
        }
    }
}