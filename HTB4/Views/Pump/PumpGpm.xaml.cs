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
    public partial class PumpGpm : CalcPage
    {
        public PumpGpm()
        {
            InitializeComponent();
            Title = "Pump GPM Calculator";
            NavigationPage.SetBackButtonTitle(this, "Pump");

        }
    }
}