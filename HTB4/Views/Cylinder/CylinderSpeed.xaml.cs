using HTB4.Views.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views.Cylinder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CylinderSpeed : CalcPage
    {
        public CylinderSpeed():base()
        {
            InitializeComponent();
            Title = "Speed Calculator";
            NavigationPage.SetBackButtonTitle(this, "Cylinder");
        }
    }
}