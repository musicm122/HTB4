using HTB4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Xamarin.Forms.Xaml;
using NavigationPage = Xamarin.Forms.NavigationPage;
using Page = Xamarin.Forms.Page;
using WindowsSpecificPage = Xamarin.Forms.PlatformConfiguration.WindowsSpecific.Page;

namespace HTB4.Views.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class CommonMenuPage : ContentPage
    {
        public MainPage RootPage { get => Xamarin.Forms.Application.Current.MainPage as MainPage; }
        public readonly List<Models.MenuItem> menuItems;

        public CommonMenuPage()
        {
            InitializeComponent();

            menuItems = GetMenuItems();

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += OnNavigationItemSelected;
            SetPlatformSpecificView(Device.RuntimePlatform);
        }

        private void SetPlatformSpecificView(string platform)
        {
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetLargeTitleDisplay(this, LargeTitleDisplayMode.Automatic);
            WindowsSpecificPage.SetToolbarPlacement(this, ToolbarPlacement.Top);

            switch (platform)
            {
                case Device.Android:
                    NavigationPage.SetHasBackButton(this, true);
                    NavigationPage.SetHasNavigationBar(this, true);
                    break;
                default:
                    NavigationPage.SetHasBackButton(this, true);
                    NavigationPage.SetHasNavigationBar(this, true);
                    break;
            }
        }

        public virtual void OnNavigationItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var id = (int)((Models.MenuItem)e.SelectedItem).Id;

            var listView = (Xamarin.Forms.ListView)sender;
            listView.SelectedItem = null;

            MenuItemKeyCheck(id);

            Device.BeginInvokeOnMainThread(() => RootPage.NavigateFromMenu(id));

            SetDetailPage(RootPage.MenuPages[id]);
        }

        void SetDetailPage(NavigationPage newPage)
        {
            if (newPage != null && RootPage.Detail != newPage)
            {
                RootPage.Detail = newPage;

                //if (Device.RuntimePlatform == Device.Android)
                //    await Task.Delay(100);

                RootPage.IsPresented = false;
            }
        }

        public virtual void MenuItemKeyCheck(int id)
        {
            if (!RootPage.MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.About:
                        //MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(AboutPage))));
                        break;
                    case (int)MenuItemType.CaseDrainMenu:
                        RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(CaseDrainMenu))));
                        break;
                    case (int)MenuItemType.CylinderMenu:
                        RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(CylinderMenu))));
                        break;
                    case (int)MenuItemType.PumpMenu:
                        RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(PumpMenu))));
                        break;
                    case (int)MenuItemType.MotorMenu:
                        RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(MotorMenu))));
                        break;
                    case (int)MenuItemType.MotorTorqueMenu:
                        RootPage.MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(MotorTorqueMenu))));
                        break;
                }
            }
        }

        public virtual List<Models.MenuItem> GetMenuItems() =>
            new List<Models.MenuItem>
            {
                new Models.MenuItem { Id = MenuItemType.About, Title="About" },
                new Models.MenuItem { Id = MenuItemType.CaseDrainMenu, Title="Case Drain" },
                new Models.MenuItem { Id = MenuItemType.CylinderMenu, Title="Cylinder" },
                new Models.MenuItem { Id = MenuItemType.PumpMenu, Title="Pump" },
                new Models.MenuItem { Id = MenuItemType.MotorMenu, Title="Motor" },
                new Models.MenuItem { Id = MenuItemType.MotorTorqueMenu, Title="Motor Torque" }
            };

        #region ShowHeader
        public event EventHandler<TextChangedEventArgs> ShowHeaderChanged = delegate { };

        public static readonly BindableProperty ShowHeaderProperty =
            BindableProperty.Create(
               "ShowHeader",
               typeof(bool),
               typeof(CommonMenuPage),
               defaultValue: false,
               defaultBindingMode: BindingMode.OneTime,
               propertyChanged: OnShowHeaderPropertyChanged);

        public bool ShowHeader
        {
            get => (bool)GetValue(ShowHeaderProperty);
            set => this.SetValue(ShowHeaderProperty, value);
        }

        protected virtual void OnShowHeaderChanged(object sender, TextChangedEventArgs args) =>
            ShowHeaderChanged?.Invoke(sender, args);

        private static void OnShowHeaderPropertyChanged(object sender, object oldValue, object newValue)
        {
            if (sender is CommonMenuPage control && newValue is bool newVal)
            {
                control.ShowHeader = newVal;
            }
        }
        #endregion ShowHeader

    }
}