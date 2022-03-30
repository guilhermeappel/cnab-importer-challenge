using CNAB.Importer.API.Infrastructure.Data;
using CNAB.Importer.API.Infrastructure.Data.Interfaces;
using CNAB.Importer.API.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CNAB.Importer.API.Configuration;

public static class DatabaseConfiguration
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPooledDbContextFactory<ImporterContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ITransactionRepository, TransactionRepository>();

        return services;
    }

    public static IHost RunMigrations(this IHost app)
    {
        using var scope = app.Services.CreateScope();

        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<IDbContextFactory<ImporterContext>>().CreateDbContext();
        context.Database.Migrate();

        return app;
    }
}