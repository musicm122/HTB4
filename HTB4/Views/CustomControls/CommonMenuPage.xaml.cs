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
        readonly List<Models.MenuItem> menuItems;

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

            var id = (int)((Models.MenuItem)e.SelectedItem).Id;
            await RootPage.NavigateFromMenu(id);
            ListViewMenu.SelectedItem = null;
        }

        public virtual List<Models.MenuItem> GetMenuItems() =>
            new List<Models.MenuItem>
            {
                new Models.MenuItem { Id = MenuItemType.About, Title="About" },
                new Models.MenuItem { Id = MenuItemType.CaseDrainMenu, Title="Case Drain" },
                new Models.MenuItem { Id = MenuItemType.CylinderMenu, Title="Cylinder" },
                new Models.MenuItem { Id = MenuItemType.PumpMenu, Title="Pump" },
                new Models.MenuItem { Id = MenuItemType.MotorMenu, Title="Motor" },
                new Models.MenuItem { Id = MenuItemType.MotorTorqueMenu, Title="Motor Torque" },
                new Models.MenuItem { Id = MenuItemType.Debug , Title="Debug" }
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