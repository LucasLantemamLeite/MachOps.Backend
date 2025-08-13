using Microsoft.AspNetCore.Mvc;

namespace MachOps.Api.Configurations.Build;

public static class BuildConfig
{
    public static WebApplicationBuilder RegisterConfig(this WebApplicationBuilder builder)
    {

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("FrontendCorsPolicy", policy =>
            {
                policy.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

        builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        builder.Services.AddHealthChecks();

        builder.Services.AddControllers();

        return builder;
    }
}