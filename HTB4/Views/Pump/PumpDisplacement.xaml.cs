using HTB4.Views.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views.Pump
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class PumpDisplacement : CalcPage
    {
        public PumpDisplacement()
        {
            InitializeComponent();
            Title = "Pump Displacement Calculator";
            NavigationPage.SetBackButtonTitle(this, "Pump");

        }
    }
}