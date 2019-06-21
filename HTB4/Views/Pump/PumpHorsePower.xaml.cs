using HTB4.Views.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views.Pump
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class PumpHorsePower : CalcPage
    {
        public PumpHorsePower()
        {
            InitializeComponent();
            Title = "Pump HP Calculator";
            NavigationPage.SetBackButtonTitle(this, "Pump");
        }
    }
}