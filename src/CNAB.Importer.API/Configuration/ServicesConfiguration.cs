using CNAB.Importer.API.Application.Services.Implementations;
using CNAB.Importer.API.Application.Services.Interfaces;

namespace CNAB.Importer.API.Configuration;

public static class ServicesConfiguration
{
    public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITransactionService, TransactionService>();

        return services;
    }
}