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
        }

        public override async void OnNavigationItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var id = (int)((Models.MenuItem)e.SelectedItem).Id;
            switch (id)
            {
                case (int)MenuItemType.CaseDrain:
                    await Navigation.PushAsync(new NavigationPage(new CaseDrainCalcPage()));
                    break;
                case (int)MenuItemType.CaseDrainGpm:
                    await Navigation.PushAsync(new NavigationPage(new CaseDrainGpmPage()));
                    break;
                default:
                    await Navigation.PushAsync(new NavigationPage(new CaseDrainMenu()));
                    break;
            }
            var listView = (ListView)sender;
            listView.SelectedItem = null;

        }
        public override List<Models.MenuItem> GetMenuItems() =>
            new List<Models.MenuItem>
            {
                new Models.MenuItem { Id = MenuItemType.CaseDrain, Title="Case Drain" },
                new Models.MenuItem { Id = MenuItemType.CaseDrainGpm, Title="Gpm" },
            };
    }
}
