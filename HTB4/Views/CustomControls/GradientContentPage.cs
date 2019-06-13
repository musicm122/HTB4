//https://github.com/sthewissen/KickassUI.InSpace/blob/master/Posy/Controls/GradientContentPage.cs
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]

    public class GradientContentPage : ContentPage
    {
        public Xamarin.Forms.Color StartColor { get; set; } = (Color)Application.Current.Resources["PrimaryDark"];

        public Xamarin.Forms.Color EndColor { get; set; } = (Color)Application.Current.Resources["SecondaryDark"];

        protected async Task RotateElement(VisualElement element, uint duration, CancellationToken cancellation)
        {
            while (!cancellation.IsCancellationRequested)
            {
                await element.RotateTo(360, duration, Easing.Linear);
                await element.RotateTo(0, 0); // reset to initial position
            }
        }
    }
}