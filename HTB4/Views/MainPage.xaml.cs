
using HTB4.Models;
using HTB4.Views;
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
        public Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        public MainPage()
        {
            InitializeComponent();

            MenuPages.Add((int)MenuItemType.About, new NavigationPage((Page)Activator.CreateInstance(typeof(AboutPage))));

            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }
        }

        public virtual void MenuItemKeyCheck(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.About:
                        //MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(AboutPage))));
                        break;
                    case (int)MenuItemType.CaseDrainMenu:
                        MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(CaseDrainMenu))));
                        break;
                    case (int)MenuItemType.CylinderMenu:
                        MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(CylinderMenu))));
                        break;
                    case (int)MenuItemType.PumpMenu:
                        MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(PumpMenu))));
                        break;
                    case (int)MenuItemType.MotorMenu:
                        MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(MotorMenu))));
                        break;
                    case (int)MenuItemType.MotorTorqueMenu:
                        MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(MotorTorqueMenu))));
                        break;
                }
            }
        }

        void SetDetailPage(NavigationPage newPage)
        {
            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                //if (Device.RuntimePlatform == Device.Android)
                //    await Task.Delay(100);

                IsPresented = false;
            }
        }

        public void NavigateFromMenu(int id)
        {
            MenuItemKeyCheck(id);
            SetDetailPage(MenuPages[id]);
        }
    }
}