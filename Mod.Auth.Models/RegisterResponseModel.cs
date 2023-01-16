namespace Mod.Auth.Models
{
    public class RegisterResponseModel
    {
        public IList<string> Errors { get; set; }

        public bool IsSuccess { get; set; }

        public string Token { get; set; }
    }
}
