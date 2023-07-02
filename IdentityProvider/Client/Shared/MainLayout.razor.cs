using System.Globalization;
using System.Text;
using Blazored.LocalStorage;
using ClientLibrary.Components.Dialogs;
using ClientLibrary.Interfaces.Particular;
using ClientLibrary.Resources;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Utilities;
using Microsoft.Extensions.Localization;
using NPOI.OpenXmlFormats;

namespace IdentityProvider.Client.Shared;

public partial class MainLayout
{
    private string selectedValue;
    private const string LanguageKey = "language";
    [Inject] public IStringLocalizer<Resource> Localizer { get; set; }

    bool openLeft = true;
    bool openRight = true;
    bool preserveOpenState = false;
    Breakpoint breakpoint = Breakpoint.Lg;
    Breakpoint breakpoint2 = Breakpoint.Lg;

    void ToggleLeftDrawer()
    {
        openLeft = !openLeft;
    }

    void ToggleRightDrawer()
    {
        openRight = !openRight;
    }

    public string SelectedLanguageValue
    {
        get => _selectedLanguageValue;
        set => SetLanguage(value);
    }


    private string[] Languages =
    {
        "en", "ru",
    };

    Justify _justify = Justify.FlexStart;
    Justify _justifyUserConfig = Justify.FlexEnd;
    private string _selectedLanguageValue;

    [Inject] public IAuthenticationService AuthenticationService { get; set; }

    [Inject] public ILocalStorageService LocalStorage { get; set; }

    [Inject] public ISnackbar SnackBarService { get; set; }

    [Inject] IDialogService DialogService { get; set; }

    public RenderFragment MyMarkup { get; set; }

    private MudTheme _theme = new()
    {
        Palette = new PaletteDark()
        {
            Primary = Colors.Red.Default,
            //Background of MudChip(dba, Front, Back,Dev  etc...)
            Secondary = Colors.Green.Accent4,
            //Text of Carts with for ex:NastyaKareva, Just Poo, I am a pooper! Poo poo poo!!!
            TextPrimary = Colors.Lime.Accent4,
            TextSecondary = Colors.Pink.Accent4,
            //The color of background in collabse expand icons
            AppbarText = Colors.Cyan.Default,
            // AppbarBackground = 
            LinesDefault = Colors.Amber.Default,
            //NavBar header text
            DrawerText = Colors.Green.Default,
            ActionDefault = Colors.Pink.Default,
        },
        // PaletteDark = new PaletteDark()
        // {
        //     Primary = Colors.Blue.Lighten1
        // },

        LayoutProperties = new LayoutProperties()
        {
            DrawerWidthLeft = "260px",
            DrawerWidthRight = "300px"
        }
    };

    private bool _isHiddenLeftDrawer;
    private bool _isHiddenRightDrawer;

    async Task Login()
    {
        var parameters = new DialogParameters();
        parameters.Add("OnClosed", EventCallback.Factory.Create(this, HandleDialogClosed));

        await DialogService.ShowAsync<LoginFormDialog>("Login", parameters);
    }


    private async Task HandleDialogClosed()
    {
        Console.WriteLine("HandleDialogClosed");
    }

    async Task Logout()
    {
        await AuthenticationService.Logout();
    }

    async Task Register()
    {
        var parameters = new DialogParameters();
        parameters.Add("OnClosed", EventCallback.Factory.Create(this, HandleDialogClosed));
        DialogOptions fullScreen = new DialogOptions() { FullScreen = true, CloseButton = true };

        await DialogService.ShowAsync<RegisterFormDialog>("Register", parameters, fullScreen);
    }

    private async Task SetLanguage(string lang)
    {
        Console.WriteLine("ChangeLang");
        Console.WriteLine($"OldSelectedLanguageValue {_selectedLanguageValue}");
        Console.WriteLine($"Lang {lang}");

        // if (_selectedLanguageValue, lang,  StringComparison.InvariantCultureIgnoreCase))
        // {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Console.WriteLine($"NewLang {lang}");
            Console.WriteLine("Localizer.ToString() ---- OnInitializedAsync");
            // var cc = CultureInfo.GetCultures(CultureTypes.AllCultures)
            //     .First(c => c.Name.Contains(lang));
            var sb = new StringBuilder(); 
            CultureInfo.CurrentCulture = new CultureInfo(lang);

        // }
        
        _selectedLanguageValue = lang;
        
        await LocalStorage.SetItemAsStringAsync(LanguageKey, lang);
    }

    protected override async Task OnInitializedAsync()
    {
        var langFromLocalStorage = await LocalStorage.ContainKeyAsync(LanguageKey)
            ? await _localStorage.GetItemAsStringAsync(LanguageKey)
            : Languages[0];

        _selectedLanguageValue = langFromLocalStorage;
        
        Console.WriteLine("Localizer.ToString() ---- OnInitializedAsync");

        // var val = Localizer.GetString(ClientResourceConstants.CreateProduct).Value;
        // Console.WriteLine($"_selectedLanguageValue ---- OnInitializedAsync: {val}");
        await base.OnInitializedAsync();
    }

    private async Task CreateProduct()
    {
    }

    private async Task CreateService()
    {
    }

    private async Task CreateCommunity()
    {
    }

    private async Task CreateBusiness()
    {
    }
}