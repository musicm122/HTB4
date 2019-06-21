using HTB4.Models;
using HTB4.Views.CustomControls;
using HTB4.Views.Pump;
using System;
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

        public override void MenuItemKeyCheck(int id)
        {
            if (!base.RootPage.MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.PumpDisplacement:
                        base.RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(PumpDisplacement))));
                        break;
                    case (int)MenuItemType.PumpGpm:
                        base.RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(PumpGpm))));
                        break;
                    case (int)MenuItemType.PumpHp:
                        base.RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(PumpHorsePower))));
                        break;
                    default:
                        base.RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(PumpMenu))));
                        break;
                }
            }
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
