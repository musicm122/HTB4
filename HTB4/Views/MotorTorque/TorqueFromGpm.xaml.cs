using HTB4.Views.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views.MotorTorque
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class TorqueFromGpm : CalcPage
    {
        public TorqueFromGpm()
        {
            InitializeComponent();
            Title = "Motor Torque From GPM Calculator";
            NavigationPage.SetBackButtonTitle(this, "Motor Torque");
        }
    }
}