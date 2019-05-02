using HTB4.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {


        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        public MainPage()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;
            MenuPages.Add((int)MenuItemType.About, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.CaseDrain:
                        MenuPages.Add(id, new NavigationPage(new CaseDrainPage()));
                        break;
                    case (int)MenuItemType.Cylinder:
                        MenuPages.Add(id, new NavigationPage(new CylinderPage()));
                        break;
                    case (int)MenuItemType.Pump:
                        MenuPages.Add(id, new NavigationPage(new PumpPage()));
                        break;
                    case (int)MenuItemType.Motor:
                        MenuPages.Add(id, new NavigationPage(new MotorPage()));
                        break;
                    case (int)MenuItemType.MotorTorque:
                        MenuPages.Add(id, new NavigationPage(new MotorTorquePage()));
                        break;

                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }

        protected async Task RotateElement(VisualElement element, uint duration, CancellationToken cancellation)
        {
            while (!cancellation.IsCancellationRequested)
            {
                await element.RotateTo(360, duration, Easing.Linear);
                await element.RotateTo(0, 0); // reset to initial position
            }
        }

    }
}