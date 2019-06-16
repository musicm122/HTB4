using HTB4.Models;
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
    public class MainMenuPage : CommonMenuPage
    {
        public MainMenuPage() : base()
        {
            Title = "Menu";
            ShowHeader = true;
            NavigationPage.SetHasBackButton(this, true);

        }
    }
}