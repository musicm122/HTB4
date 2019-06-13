using HTB4.ViewModels.DesignTimeViewModels;
using HTB4.Views.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]

    public partial class CaseDrainPage : ContentPage
    {
        public CaseDrainPage()
        {
            InitializeComponent();

            if (DesignMode.IsDesignModeEnabled)
            {
                this.BindingContext = DesignTimeViewModels.GetCaseDrainVM();
            }
        }
    }
}
