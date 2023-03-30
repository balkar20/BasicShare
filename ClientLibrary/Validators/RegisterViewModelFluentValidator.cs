using System.Text.RegularExpressions;
using FluentValidation;
using IdentityProvider.Shared;

namespace ClientLibrary.Validators;

public class RegisterViewModelFluentValidator: AbstractValidator<RegisterViewModel>
{
    public RegisterViewModelFluentValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .Length(1,40);
        RuleFor(x => x.UserName)
            .NotEmpty()
            .Length(1,30);
        RuleFor(x => x.Email)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty()
            .EmailAddress()
            .Must(IsUniqueAsync);
        RuleFor(p => p.Password).NotEmpty().WithMessage("Your password cannot be empty")
            .MinimumLength(8).WithMessage("Your password length must be at least 8.")
            .Must(HasValidPassword);
        RuleFor(p => p.ConfirmPassword).NotEmpty().WithMessage("Your password cannot be empty")
            .MinimumLength(8).WithMessage("Your password length must be at least 8.")
            .Must(HasValidPassword);
        RuleFor(p => p.Year)
            .NotEmpty()
            .Must(IsValidAgeAsync);
            
    }

    private async Task ValidateAsync(object createWithOptions, Func<object, object> cancellation)
    {
        throw new NotImplementedException();
    }

    private bool IsUniqueAsync(string email)
    {
        
        // Simulates a long running http call
        // await Task.Delay(500);
        return email.ToLower() != "test@test.com";
    }

    private  bool IsValidAgeAsync(int year)
    {
        // Simulates a long running http call
        // await Task.Delay(500);
        return year >= 18 && year <= 80;
    }
    
    private  bool HasValidPassword(string pw)
    {
        var lowercase = new Regex("[a-z]+");
        var uppercase = new Regex("[A-Z]+");
        var digit = new Regex("(\\d)+");
        var symbol = new Regex("(\\W)+");

        return (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw));
    }
}