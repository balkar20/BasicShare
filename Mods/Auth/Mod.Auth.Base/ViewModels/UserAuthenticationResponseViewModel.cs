namespace Mod.Auth.Base.ViewModels
{
    internal class UserAuthenticationResponseViewModel
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}
