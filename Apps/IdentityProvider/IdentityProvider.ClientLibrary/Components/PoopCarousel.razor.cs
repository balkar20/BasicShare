using MudBlazor;

namespace ClientLibrary.Components;

public partial class PoopCarousel
{
    private string contentHeight = "100%";
    private string firstImage = "COMMUNITY.png";
    private string secondImage = "products1.jpg";
    private string thirdImage = "photo_2024-05-09_15-27-47.jpg";
    private bool arrows = true;
    private bool bullets = true;
    private bool enableSwipeGesture = true;
    private bool autocycle = true;
    private Transition transition = Transition.Fade;
}