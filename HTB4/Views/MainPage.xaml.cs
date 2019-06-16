
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
                await Task.Run(() =>
                {
                    switch (id)
                    {
                        case (int)MenuItemType.About:
                            MenuPages.Add(id, new NavigationPage(new AboutPage()));
                            break;
                        case (int)MenuItemType.CaseDrainMenu:
                            MenuPages.Add(id, new NavigationPage(new CaseDrainMenu()));
                            break;
                        case (int)MenuItemType.CylinderMenu:
                            MenuPages.Add(id, new NavigationPage(new CylinderMenu()));
                            break;
                        case (int)MenuItemType.PumpMenu:
                            MenuPages.Add(id, new NavigationPage(new PumpMenu()));
                            break;
                        case (int)MenuItemType.MotorMenu:
                            MenuPages.Add(id, new NavigationPage(new MotorMenu()));
                            break;
                        case (int)MenuItemType.MotorTorqueMenu:
                            MenuPages.Add(id, new NavigationPage(new MotorTorqueMenu()));
                            break;
                        case (int)MenuItemType.Debug:
                            MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                            break;

                    }
                });
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