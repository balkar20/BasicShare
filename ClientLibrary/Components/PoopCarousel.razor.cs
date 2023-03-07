using MudBlazor;

namespace ClientLibrary.Components;

public partial class PoopCarousel
{
    private bool arrows = true;
    private bool bullets = true;
    private bool enableSwipeGesture = true;
    private bool autocycle = true;
    private Transition transition = Transition.Slide;
}