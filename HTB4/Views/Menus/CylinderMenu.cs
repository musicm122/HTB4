using HTB4.Models;
using HTB4.Views.CaseDrain;
using HTB4.Views.CustomControls;
using HTB4.Views.Cylinder;
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
    public class CylinderMenu : CommonMenuPage
    {
        public CylinderMenu() : base()
        {
            Title = "Cylinder";
        }

        public override void OnNavigationItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var id = (int)((Models.MenuItem)e.SelectedItem).Id;
            switch (id)
            {
                case (int)MenuItemType.CylinderSpeed:
                    Navigation.PushAsync(new NavigationPage(new CylinderSpeed()));
                    break;
                case (int)MenuItemType.CylinderPsi:
                    Navigation.PushAsync(new NavigationPage(new CylinderPsi()));
                    break;
                case (int)MenuItemType.CylinderForce:
                    Navigation.PushAsync(new NavigationPage(new CylinderForce()));
                    break;
                default:
                    Navigation.PushAsync(new NavigationPage(new CylinderMenu()));
                    break;
            }
            var listView = (ListView)sender;
            listView.SelectedItem = null;

        }

        public override List<Models.MenuItem> GetMenuItems() =>
            new List<Models.MenuItem>
            {
                new Models.MenuItem { Id = MenuItemType.CylinderForce, Title="Force" },
                new Models.MenuItem { Id = MenuItemType.CylinderPsi, Title="PSI" },
                new Models.MenuItem { Id = MenuItemType.CylinderSpeed, Title="Speed" },
            };
    }

}
