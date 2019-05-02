//https://github.com/sthewissen/KickassUI.InSpace/blob/master/Posy/Controls/GradientContentPage.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HTB4.Views.CustomControls
{
    public class GradientContentPage : ContentPage
    {
        public Xamarin.Forms.Color StartColor { get; set; }
        public Xamarin.Forms.Color EndColor { get; set; }

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