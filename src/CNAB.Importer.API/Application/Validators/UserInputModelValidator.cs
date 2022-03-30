using CNAB.Importer.API.Application.InputModels;
using FluentValidation;

namespace CNAB.Importer.API.Application.Validators;

public class UserInputModelValidator : AbstractValidator<UserInputModel>
{
    public UserInputModelValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(20);
    }
}