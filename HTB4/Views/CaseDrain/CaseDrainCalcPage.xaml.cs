using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using WindowsSpecificPage = Xamarin.Forms.PlatformConfiguration.WindowsSpecific.Page;
using HTB4.Views.CustomControls;

namespace HTB4.Views.CaseDrain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class CaseDrainCalcPage : CalcPage
    {
        public CaseDrainCalcPage() : base()
        {
            InitializeComponent();
            Title = "Case Drain Calculator";
            NavigationPage.SetBackButtonTitle(this, "Case Drain");
        }
    }
}