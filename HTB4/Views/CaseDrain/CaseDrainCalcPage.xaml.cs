using HTB4.ViewModels.DesignTimeViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views.CaseDrain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class CaseDrainCalcPage : ContentPage
    {
        public CaseDrainCalcPage()
        {
            InitializeComponent();
        }
    }
}