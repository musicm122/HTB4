using HTB4.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;

        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.About, Title="About" },
                new HomeMenuItem {Id = MenuItemType.CaseDrain, Title="Case Drain Calculator" },
                new HomeMenuItem {Id = MenuItemType.Pump, Title="Pump Calculator" },
                new HomeMenuItem {Id = MenuItemType.Cylinder, Title="Cylinder Calculator" },
                new HomeMenuItem {Id = MenuItemType.Motor, Title="Motor Calculator" }

                //new HomeMenuItem {Id = MenuItemType.ConversionTable1, Title="Conversion Table 1" },
                //new HomeMenuItem {Id = MenuItemType.ConversionTable2, Title="Conversion Table 2" },
                //new HomeMenuItem {Id = MenuItemType.ConversionTable3, Title="Conversion Table 3" },
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