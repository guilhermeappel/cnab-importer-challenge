using CNAB.Importer.API.Infrastructure.Application;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CNAB.Importer.UnitTests.Infrastructure;

public abstract class DependencyInjectionTest
{
    protected readonly IOptionsMonitor<AppSettings> AppSettings;

    protected DependencyInjectionTest()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        var services = new ServiceCollection();
        services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

        AppSettings = services.BuildServiceProvider().GetRequiredService<IOptionsMonitor<AppSettings>>();
    }
}