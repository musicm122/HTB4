using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Xamarin.Forms.Xaml;
using NavigationPage = Xamarin.Forms.NavigationPage;
using WindowsSpecificPage = Xamarin.Forms.PlatformConfiguration.WindowsSpecific.Page;

namespace HTB4.Views.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class CalcPage : ContentPage
    {
        public CalcPage()
        {
            InitializeComponent();
            SetPlatformSpecificView(Device.RuntimePlatform);
        }

        public virtual void SetPlatformSpecificView(string platform)
        {
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetLargeTitleDisplay(this, LargeTitleDisplayMode.Automatic);
            WindowsSpecificPage.SetToolbarPlacement(this, ToolbarPlacement.Top);

            switch (platform)
            {
                case Device.Android:
                    NavigationPage.SetHasBackButton(this, true);
                    NavigationPage.SetHasNavigationBar(this, true);
                    break;
                default:
                    NavigationPage.SetHasBackButton(this, true);
                    NavigationPage.SetHasNavigationBar(this, true);
                    break;
            }

        }

    }
}