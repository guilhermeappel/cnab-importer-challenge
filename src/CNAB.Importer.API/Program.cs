using CNAB.Importer.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseIISIntegration();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddServicesConfiguration();

var app = builder.Build();

app.UseApiConfiguration();
app.RunMigrations();

app.Run();
