using MachOps.Api.Configurations.Injections;
using MachOps.Api.Configurations.Build;
using MachOps.Api.Configurations.App;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .RegisterQueries()
    .RegisterRepositories()
    .RegisterHandlers()
    .RegisterUseCases()
    .RegisterServices(builder.Configuration);

builder.RegisterConfig();

var app = builder.Build();

app.RegisterConfig();

app.Run();
