using HTB4.Models;
using HTB4.Views.CustomControls;
using HTB4.Views.Pump;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public class PumpMenu : CommonMenuPage
    {
        public PumpMenu() : base()
        {
            Title = "Pump";
        }


        public override async void OnNavigationItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var id = (int)((Models.MenuItem)e.SelectedItem).Id;
            switch (id)
            {
                case (int)MenuItemType.PumpDisplacement:
                    await Navigation.PushAsync(new NavigationPage(new PumpDisplacement()));
                    break;
                case (int)MenuItemType.PumpGpm:
                    await Navigation.PushAsync(new NavigationPage(new PumpGpm()));
                    break;
                case (int)MenuItemType.PumpHp:
                    await Navigation.PushAsync(new NavigationPage(new PumpHorsePower()));
                    break;
                default:
                    await Navigation.PushAsync(new NavigationPage(new PumpMenu()));
                    break;
            }
            var listView = (ListView)sender;
            listView.SelectedItem = null;

        }


        public override List<Models.MenuItem> GetMenuItems() =>
            new List<Models.MenuItem>
            {
                new Models.MenuItem { Id = MenuItemType.PumpDisplacement , Title="Displacement" },
                new Models.MenuItem { Id = MenuItemType.PumpHp , Title="Hp" },
                new Models.MenuItem { Id = MenuItemType.PumpGpm , Title="Gpm" },
            };
    }

}
