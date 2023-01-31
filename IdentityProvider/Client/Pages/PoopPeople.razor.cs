using Microsoft.AspNetCore.Components.Forms;
using IdentityProvider.Client.Shared;
using IdentityProvider.Shared;
using TinyCsvParser;
using System.Text;

namespace IdentityProvider.Client.Pages
{
    public partial class PoopPeople
    {
        private List<PooperViewModel> PooperlList = new() {new()
                 {
                     Id = 1, Name = "VladCoach", AmountOfPoops = 0
                 },
            new()
                {
                    Id = 2, Name = "Drews", AmountOfPoops = 0
                }
        };

        private void LoadPhoto(InputFileChangeEventArgs obj)
        {
            throw new NotImplementedException();
        }
    }

}