using HTB4.Views.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views.Motor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class MotorSpeed : CalcPage
    {
        public MotorSpeed()
        {
            InitializeComponent();
            Title = "Motor Speed Calculator";
            NavigationPage.SetBackButtonTitle(this, "Motor");
        }
    }
}