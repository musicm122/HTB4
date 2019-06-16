using HTB4.Models;
using HTB4.Views.CaseDrain;
using HTB4.Views.CustomControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

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
            this.ShowHeader = false;
        }
        public override void OnNavigationItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var id = (int)((HomeMenuItem)e.SelectedItem).Id;
            switch (id)
            {
                case (int)MenuItemType.CaseDrain:
                    Navigation.PushAsync(new NavigationPage(new CaseDrainCalcPage()));
                    break;
                case (int)MenuItemType.CaseDrainGpm:
                    Navigation.PushAsync(new NavigationPage(new CaseDrainGpmPage()));
                    break;
                default:
                    Navigation.PushAsync(new NavigationPage(new AboutPage()));
                    break;
            }
            var listView = (ListView)sender;
            listView.SelectedItem = null;

        }
        public override List<HomeMenuItem> GetMenuItems() =>
            new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.CaseDrain, Title="Calculate Case Drain" },
                new HomeMenuItem {Id = MenuItemType.CaseDrainGpm, Title="Calculate Gpm" },
            };
    }
}
