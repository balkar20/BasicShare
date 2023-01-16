using System.ComponentModel.DataAnnotations;

namespace Mod.Auth.Base.ViewModels
{
    internal class UserAuthenticationViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
