using HTB4.Models;
using HTB4.Views.CaseDrain;
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
    public class CaseDrainMenu : CommonMenuPage
    {
        public CaseDrainMenu() : base()
        {
            Title = "Case Drain";
        }

        public override async void OnNavigationItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var id = (int)((Models.MenuItem)e.SelectedItem).Id;
            if (!base.RootPage.MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.CaseDrain:
                        base.RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(CaseDrainCalcPage))));
                        break;

                    case (int)MenuItemType.CaseDrainGpm:
                        base.RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(CaseDrainGpmPage))));
                        break;

                    default:
                        base.RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(CaseDrainMenu))));
                        break;
                }
            }
            var listView = (ListView)sender;
            listView.SelectedItem = null;
            var newPage = base.RootPage.MenuPages[id];

            if (newPage != null && base.RootPage.Detail != newPage)
            {
                base.RootPage.Detail = newPage;

                //if (Device.RuntimePlatform == Device.Android)
                //    await Task.Delay(100);

                base.RootPage.IsPresented = false;
            }
        }

        public override void MenuItemKeyCheck(int id)
        {
            if (!base.RootPage.MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.CaseDrain:
                        base.RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(CaseDrainCalcPage))));
                        break;

                    case (int)MenuItemType.CaseDrainGpm:
                        base.RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(CaseDrainGpmPage))));
                        break;

                    default:
                        base.RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(CaseDrainMenu))));
                        break;
                }
            }
        }

        public override List<Models.MenuItem> GetMenuItems() =>
            new List<Models.MenuItem>
            {
                new Models.MenuItem { Id = MenuItemType.CaseDrain, Title="Case Drain" },
                new Models.MenuItem { Id = MenuItemType.CaseDrainGpm, Title="Gpm" },
            };
    }
}