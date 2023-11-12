using MudBlazor;

namespace ClientLibrary.Components;

public partial class PoopCarousel
{
    private string contentHeight = "100%";
    private string firstImage = "COMMUNITY.png";
    private string secondImage = "products1.jpg";
    private bool arrows = true;
    private bool bullets = true;
    private bool enableSwipeGesture = true;
    private bool autocycle = true;
    private Transition transition = Transition.Fade;
}