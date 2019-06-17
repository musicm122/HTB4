using HTB4.Models;
using HTB4.Views.CustomControls;
using HTB4.Views.Motor;
using HTB4.Views.MotorTorque;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public class MotorTorqueMenu : CommonMenuPage
    {
        public MotorTorqueMenu() : base()
        {
            Title = "Motor Torque";
        }

        public override async void OnNavigationItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var id = (int)((Models.MenuItem)e.SelectedItem).Id;
            switch (id)
            {
                case (int)MenuItemType.MotorTorqueGpm:
                    await Navigation.PushAsync(new NavigationPage(new TorqueFromGpm()));
                    break;
                case (int)MenuItemType.MotorTorqueHp:
                    await Navigation.PushAsync(new NavigationPage(new TorqueFromHp()));
                    break;
                case (int)MenuItemType.MotorTorqueVelocity:
                    await Navigation.PushAsync(new NavigationPage(new TorqueVelocity()));
                    break;
                default:
                    await Navigation.PushAsync(new NavigationPage(new MotorTorqueMenu()));
                    break;
            }

            var listView = (ListView)sender;
            listView.SelectedItem = null;
        }


        public override List<Models.MenuItem> GetMenuItems() =>
            new List<Models.MenuItem>
            {
                new Models.MenuItem { Id = MenuItemType.MotorTorqueGpm , Title="Gpm" },
                new Models.MenuItem { Id = MenuItemType.MotorTorqueHp, Title="Hp" },
                new Models.MenuItem { Id = MenuItemType.MotorTorqueVelocity , Title="Velocity" },
            };


    }

}
