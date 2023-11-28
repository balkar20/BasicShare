namespace Mod.Auth.Base.ViewModels
{
    internal class RegisterResponseViewModel
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}
