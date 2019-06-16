using HTB4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommonMenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        readonly List<HomeMenuItem> menuItems;

        public CommonMenuPage()
        {
            InitializeComponent();

            menuItems = GetMenuItems();

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += OnNavigationItemSelected;
            NavigationPage.SetHasBackButton(this, true);
        }

        public virtual async void OnNavigationItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var id = (int)((HomeMenuItem)e.SelectedItem).Id;
            await RootPage.NavigateFromMenu(id);
            ListViewMenu.SelectedItem = null;

        }

        public virtual List<HomeMenuItem> GetMenuItems() =>
            new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.About, Title="About" },
                new HomeMenuItem {Id = MenuItemType.CaseDrainMenu, Title="Case Drain" },
                new HomeMenuItem {Id = MenuItemType.CylinderMenu, Title="Cylinder" },
                new HomeMenuItem {Id = MenuItemType.Pump, Title="Pump" },
                new HomeMenuItem {Id = MenuItemType.Motor, Title="Motor" },
                new HomeMenuItem {Id = MenuItemType.MotorTorque, Title="Motor Torque" },
                new HomeMenuItem {Id = MenuItemType.Debug , Title="Debug" }
            };

        #region ShowHeader
        public event EventHandler<TextChangedEventArgs> ShowHeaderChanged = delegate { };

        public static readonly BindableProperty ShowHeaderProperty =
            BindableProperty.Create(
               "ShowHeader",
               typeof(bool),
               typeof(CommonMenuPage),
               defaultValue: default(bool),
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