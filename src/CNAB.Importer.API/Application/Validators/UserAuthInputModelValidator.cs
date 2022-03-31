using CNAB.Importer.API.Application.InputModels;
using CNAB.Importer.API.Application.Utils;
using CNAB.Importer.API.Infrastructure.Application;
using CNAB.Importer.API.Infrastructure.Data.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace CNAB.Importer.API.Application.Validators;

public class UserAuthInputModelValidator : AbstractValidator<UserAuthInputModel>
{
    private readonly IUserRepository _repository;
    private readonly IOptionsMonitor<AppSettings> _appSettings;

    public UserAuthInputModelValidator(IUserRepository repository, IOptionsMonitor<AppSettings> appSettings)
    {
        _repository = repository;
        _appSettings = appSettings;

        RuleFor(x => x)
            .MustAsync(BeValidUserAsync).OverridePropertyName("InvalidLogin").WithMessage("Invalid username or password");
    }

    public async Task<bool> BeValidUserAsync(UserAuthInputModel user, CancellationToken cancellationToken)
    {
        var argon2HashManager = new Argon2HashManager(_appSettings);

        var databaseUser = (await _repository.GetAsync(x => x.Username == user.Username, cancellationToken)).FirstOrDefault();

        return databaseUser != null && argon2HashManager.VerifyPasswordHash(user.Password, databaseUser.Password);
    }
}