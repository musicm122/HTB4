//https://github.com/sthewissen/KickassUI.InSpace/blob/master/Posy/Controls/GradientContentPage.cs
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]

    public class GradientContentView : ContentView
    {
        public Xamarin.Forms.Color StartColor { get; set; } = (Color)Application.Current.Resources["PrimaryDark"];

        public Xamarin.Forms.Color EndColor { get; set; } = (Color)Application.Current.Resources["SecondaryDark"];

        private SKCanvasView CanvasView { get; set; } = new SKCanvasView();

        public GradientContentView()
        {
            CanvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = CanvasView;
            DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;
        }

        private void DeviceDisplay_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            CanvasView.InvalidateSurface();
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            //var colors = new SKColor[] { StartColor.ToSKColor(), EndColor.ToSKColor() };
            var colors = new SKColor[] { Color.Green.ToSKColor(), Color.Red.ToSKColor(), Color.Black.ToSKColor() };

            SKPoint startPoint = new SKPoint(0, 0);
            SKPoint endPoint = new SKPoint(0, info.Height);

            var shader = SKShader.CreateLinearGradient(startPoint, endPoint, colors, null, SKShaderTileMode.Clamp);

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Shader = shader
            };

            canvas.DrawRect(new SKRect(0, 0, info.Width, info.Height), paint);
        }

    }
}