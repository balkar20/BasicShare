using FluentValidation;
using IdentityProvider.Shared;

namespace ClientLibrary.Validators;

public class LoginViewModelFluentValidator: AbstractValidator<LoginViewModel>
{
    public LoginViewModelFluentValidator()
    {
        RuleFor(x => x.Email)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty()
            .EmailAddress()
            .MustAsync(async (value, cancellationToken) => await IsUniqueAsync(value));
        RuleFor(x => x.Password)
            .NotEmpty();
    }

    private async Task<bool> IsUniqueAsync(string email)
    {
        // Simulates a long running http call
        await Task.Delay(2000);
        return email.ToLower() != "test@test.com";
    }
}