using System.Net;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using ClientLibrary.Interfaces;
using ClientLibrary.Interfaces.Particular;
using Core.Transfer;
using FluentValidation;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Extensions;
using TinyCsvParser.Tokenizer.RFC4180;

namespace ClientLibrary.Components.Forms;

public partial class RegisterForm : ComponentBase
{
    
    
    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }
    
    MudForm form;
    bool success;
    string[] errors = { };
    
    private IBaseMvvmViewModel<RegisterViewModel> _mvvmViewModel;

    private async Task OnValidSubmit()
    {
         await form.Validate();
         if (form.IsValid)
         {
             await AuthenticationService.RegisterAsync();
         }
    }

    private Func<object, string, Task<IEnumerable<string>>> ValidateFormAsync => async (model, propertyName) =>
    {
        var result = await _mvvmViewModel.Validator.ValidateAsync(
            ValidationContext<RegisterViewModel>.CreateWithOptions((RegisterViewModel)model,
                x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };

    protected override async Task OnInitializedAsync()
    {
        _mvvmViewModel = AuthenticationService.RegisterCrudService.MvvmViewModel;
        _mvvmViewModel.Data = new RegisterViewModel();
        await base.OnInitializedAsync();
    }
}