using HTB4.Models;
using HTB4.Views.CustomControls;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : GradientContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        readonly List<HomeMenuItem> menuItems;

        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.About, Title="About" },
                new HomeMenuItem {Id = MenuItemType.CaseDrain, Title="Case Drain" },
                new HomeMenuItem {Id = MenuItemType.Cylinder, Title="Cylinder" },
                new HomeMenuItem {Id = MenuItemType.Pump, Title="Pump" },
                new HomeMenuItem {Id = MenuItemType.Motor, Title="Motor" },
                new HomeMenuItem {Id = MenuItemType.MotorTorque, Title="Motor Torque" },
                new HomeMenuItem {Id = MenuItemType.Debug , Title="Debug" }

            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}