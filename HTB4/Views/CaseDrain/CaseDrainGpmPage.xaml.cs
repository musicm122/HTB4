using HTB4.Views.CustomControls;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views.CaseDrain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class CaseDrainGpmPage : CalcPage
    {
        public CaseDrainGpmPage()
        {
            InitializeComponent();
            Title = "GPM Calculator";
            NavigationPage.SetBackButtonTitle(this, "Case Drain");
        }
    }
}