using MachOps.Application.Interfaces.Queries;
using MachOps.Application.Interfaces.Repositories;

namespace MachOps.Application.Shared.UseCases.Base.Utils;

public record Queries(IUserAccountQuery UserQuery, IMachineryQuery MachineryQuery);
public record Repositories(IUserAccountRepository UserRepository, IMachineryRepository MachineryRepository);