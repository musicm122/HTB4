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

        public override void MenuItemKeyCheck(int id)
        {
            if (!RootPage.MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.CylinderForce:
                        RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(CylinderForce))));
                        break;
                    case (int)MenuItemType.CylinderPsi:
                        RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(CylinderPsi))));
                        break;
                    case (int)MenuItemType.CylinderSpeed:
                        RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(CylinderSpeed))));
                        break;
                    default:
                        RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(CylinderMenu))));
                        break;
                }
            }
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
