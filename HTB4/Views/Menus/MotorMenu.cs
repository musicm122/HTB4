using HTB4.Models;
using HTB4.Views.CustomControls;
using HTB4.Views.Motor;
using System;
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

        public override void MenuItemKeyCheck(int id)
        {
            if (!base.RootPage.MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.MotorGpm:
                        base.RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(MotorGpm))));
                        break;
                    case (int)MenuItemType.MotorSpeed:
                        base.RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(MotorSpeed))));
                        break;
                    case (int)MenuItemType.MotorFluidMotion:
                        base.RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(MotorFluidMotion))));
                        break;
                    default:
                        base.RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(MotorMenu))));
                        break;
                }
            }
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
