using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class Header : ContentView
    {
        public Header()
        {
            InitializeComponent();
        }

        #region Icon

        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(
               "Icon",
               typeof(string),
               typeof(Header),
               defaultValue: default(string),
               defaultBindingMode: BindingMode.OneTime,
               propertyChanged: OnIconPropertyChanged);

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => this.SetValue(IconProperty, value);
        }

        private static void OnIconPropertyChanged(object sender, object oldValue, object newValue)
        {

            if (sender is Header control && newValue is string newIcon)
            {
                control.Icon = newIcon;
            }
        }
        #endregion Icon

        #region Text
        public event EventHandler<TextChangedEventArgs> TextChanged = delegate { };

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(
               "Text",
               typeof(string),
               typeof(Header),
               defaultValue: default(string),
               defaultBindingMode: BindingMode.OneTime,
               propertyChanged: OnTextPropertyChanged);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => this.SetValue(TextProperty, value);
        }

        protected virtual void OnTextChanged(object sender, TextChangedEventArgs args) =>
            TextChanged?.Invoke(sender, args);

        private static void OnTextPropertyChanged(object sender, object oldValue, object newValue)
        {
            if (sender is Header control && newValue is string newText)
            {
                control.Text = newText;
            }
        }
        #endregion Text

    }
}