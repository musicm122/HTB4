using HTB4.Models;
using HTB4.Views.CustomControls;
using HTB4.Views.Motor;
using HTB4.Views.MotorTorque;
using System;
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

        public override void MenuItemKeyCheck(int id)
        {
            if (!base.RootPage.MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.MotorTorqueGpm:
                        RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(TorqueFromGpm))));
                        break;
                    case (int)MenuItemType.MotorTorqueHp:
                        RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(TorqueFromHp))));
                        break;
                    case (int)MenuItemType.MotorTorqueVelocity:
                        RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(TorqueVelocity))));
                        break;
                    default:
                        RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(MotorTorqueMenu))));
                        break;
                }
            }
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
