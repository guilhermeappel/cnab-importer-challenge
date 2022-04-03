using CNAB.Importer.API.Application.InputModels;
using CNAB.Importer.API.Infrastructure.Data.Interfaces;
using FluentValidation;

namespace CNAB.Importer.API.Application.Validators;

public class UserRegisterInputModelValidator : AbstractValidator<UserRegisterInputModel>
{
    private readonly IUserRepository _repository;

    public UserRegisterInputModelValidator(IUserRepository repository)
    {
        _repository = repository;

        RuleFor(x => x.Username)
            .NotEmpty()
            .MaximumLength(100)
            .MustAsync(BeUniqueEmailAsync).WithMessage("User already registered");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.PasswordConfirmation)
            .NotEmpty()
            .MaximumLength(20);
    }

    public async Task<bool> BeUniqueEmailAsync(string username, CancellationToken cancellationToken)
    {
        return !(await _repository.GetAsync(filter: x => x.Username == username, cancellationToken: cancellationToken)).Any();
    }
}