using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Util;

namespace HTB4.Droid
{
    [Activity(Label = "HTB4", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;

                base.OnCreate(savedInstanceState);
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

                LoadApplication(new App());
            }
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\r\n" + ex.StackTrace;
                Log.Error("HTB4-Test", msg);
                throw;
            }
        }
    }
}