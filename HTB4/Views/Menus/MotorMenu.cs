using HTB4.Models;
using HTB4.Views.CustomControls;
using HTB4.Views.Motor;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public class MotorMenu : CommonMenuPage
    {
        public MotorMenu() : base()
        {
            Title = "Motor Menu";
        }

        public override async void OnNavigationItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var id = (int)((Models.MenuItem)e.SelectedItem).Id;
            switch (id)
            {
                case (int)MenuItemType.MotorGpm:
                    await Navigation.PushAsync(new NavigationPage(new MotorGpm()));
                    break;
                case (int)MenuItemType.MotorSpeed:
                    await Navigation.PushAsync(new NavigationPage(new MotorSpeed()));
                    break;
                case (int)MenuItemType.MotorFluidMotion:
                    await Navigation.PushAsync(new NavigationPage(new HTB4.Views.Motor.MotorFluidMotion()));
                    break;
                default:
                    await Navigation.PushAsync(new NavigationPage(new MotorMenu()));
                    break;
            }
            var listView = (ListView)sender;
            listView.SelectedItem = null;
        }

        public override List<Models.MenuItem> GetMenuItems() =>
            new List<Models.MenuItem>
            {
                new Models.MenuItem { Id = MenuItemType.MotorSpeed , Title="Speed" },
                new Models.MenuItem { Id = MenuItemType.MotorFluidMotion , Title="Torque" },
                new Models.MenuItem { Id = MenuItemType.MotorGpm , Title="Gpm" },
            };

    }
}
