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
    public partial class TorqueFromHp : CalcPage
    {
        public TorqueFromHp()
        {
            InitializeComponent();
            Title = "Motor Torque From HP Calculator";
            NavigationPage.SetBackButtonTitle(this, "Motor Torque");

        }
    }
}