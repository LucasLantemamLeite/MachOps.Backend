namespace MachOps.Api.Configurations.App;

public static class AppConfig
{
    public static WebApplication RegisterConfig(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseRouting();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHealthChecks("/v1/health");

        app.MapControllers();

        return app;
    }
}