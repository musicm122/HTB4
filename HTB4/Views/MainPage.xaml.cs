
using HTB4.Models;
using HTB4.Views.CaseDrain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]

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
                        MenuPages.Add(id, new NavigationPage(new CaseDrainCalcPage()));
                        break;
                    case (int)MenuItemType.CaseDrainGpm:
                        MenuPages.Add(id, new NavigationPage(new CaseDrainGpmPage()));
                        break;
                    case (int)MenuItemType.CaseDrainMenu:
                        MenuPages.Add(id, new NavigationPage(new CaseDrainMenu()));
                        break;
                    case (int)MenuItemType.CylinderMenu:
                        MenuPages.Add(id, new NavigationPage(new CylinderMenu()));
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
                    case (int)MenuItemType.Debug:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;

                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                //if (Device.RuntimePlatform == Device.Android)
                //    await Task.Delay(100);

                IsPresented = false;
            }
        }

    }
}