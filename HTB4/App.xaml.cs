using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HTB4.Views;
using Autofac;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HTB4
{
    public partial class App : Application
    {
        private const string AppCenterAndroidId = "fe8bf66a-4e62-4c6d-8d7b-0aec79ac75ae";
        private const string AppCenterIosId = "bb556b65-66c3-47bb-86c7-cfa47618a783";

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start(
                $"android={AppCenterAndroidId};ios={AppCenterIosId};",
                typeof(Analytics),
                typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
