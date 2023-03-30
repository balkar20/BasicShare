namespace Mod.Auth.Models
{
    public class PooperSaveResponseModel
    {
        public IList<string> Errors { get; set; }

        public bool IsSuccess { get; set; }
    }
}
