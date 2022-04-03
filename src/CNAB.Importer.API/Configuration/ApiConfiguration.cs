using CNAB.Importer.API.Application.ExtensionMethods;
using CNAB.Importer.API.Infrastructure.Application;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace CNAB.Importer.API.Configuration;

public static class ApiConfiguration
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddOptions<AppSettings>().Bind(configuration.GetSection("AppSettings"));

        services
            .AddControllers()
            .AddFluentValidation(fv =>
            {
                fv.DisableDataAnnotationsValidation = true;
                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                fv.ValidatorOptions.PropertyNameResolver = CamelCasePropertyNameResolver.ResolvePropertyName;
            });

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(configuration["AppSettings:AuthTokenSecretKey"]);

                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = false
                };
            });

        services
            .Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = new Dictionary<string, IEnumerable<string>?>();

                    context.ModelState
                        .Select(ms => new
                        {
                            Key = ms.Key,
                            Value = ms.Value?.Errors.Select(x => x.ErrorMessage)
                        })
                        .ToList()
                        .ForEach(x => errors.Add(x.Key.ToCamelCase(), x.Value));

                    return new BadRequestObjectResult(new
                    {
                        Title = "Invalid arguments to the API",
                        Status = 400,
                        Errors = errors
                    });
                };
            });

        services.AddCors(options =>
        {
            options.AddPolicy("Total",
                builder =>
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
        });

        services.AddSwaggerGen();

        return services;
    }

    public static WebApplication UseApiConfiguration(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseCors("Total");

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}