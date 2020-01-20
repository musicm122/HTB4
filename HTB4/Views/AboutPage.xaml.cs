using HTB4.Views.CustomControls;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class AboutPage : CalcPage
    {
        private readonly string feedbackUrl = "https://trello.com/b/NDKBuLqs/hydraulic-toolbox";
        public AboutPage()
        {
            InitializeComponent();
        }
    }
}