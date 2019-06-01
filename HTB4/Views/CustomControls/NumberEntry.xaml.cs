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
    public partial class NumberEntry : ContentView
    {
        #region Number
        public event EventHandler<TextChangedEventArgs> NumberChanged = delegate { };

        public static readonly BindableProperty NumberProperty =
            BindableProperty.Create(
               "Number",
               typeof(float),
               typeof(NumberEntry),
               defaultValue: 0.0f,
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: OnNumberPropertyChanged);

        public float Number
        {
            get => (float)GetValue(NumberProperty);
            set => this.SetValue(NumberProperty, value);
        }

        protected virtual void OnNumberChanged(object sender, TextChangedEventArgs args) =>
            NumberChanged?.Invoke(sender, args);

        private static void OnNumberPropertyChanged(object sender, object oldValue, object newValue)
        {
            if (sender is NumberEntry control && newValue is float newNumber)
            {
                control.Number = newNumber;
            }
        }

        #endregion Number

        #region Label
        public event EventHandler<TextChangedEventArgs> LabelChanged = delegate { };

        public static readonly BindableProperty LabelProperty =
            BindableProperty.Create(
               "Label",
               typeof(string),
               typeof(NumberEntry),
               defaultValue: default(string),
               propertyChanged: OnLabelPropertyChanged);

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => this.SetValue(LabelProperty, value);
        }

        protected virtual void OnLabelChanged(object sender, TextChangedEventArgs args) =>
            LabelChanged?.Invoke(sender, args);

        private static void OnLabelPropertyChanged(object sender, object oldValue, object newValue)
        {
            if (sender is NumberEntry control && newValue is string newText)
            {
                control.Label = newText;
            }
        }
        #endregion Label

        #region Placeholder
        public event EventHandler<TextChangedEventArgs> PlaceholderChanged = delegate { };

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(
               "Placeholder",
               typeof(string),
               typeof(NumberEntry),
               defaultValue: default(string),
               propertyChanged: OnPlaceholderPropertyChanged);

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => this.SetValue(PlaceholderProperty, value);
        }

        protected virtual void OnPlaceholderChanged(object sender, TextChangedEventArgs args) =>
            PlaceholderChanged?.Invoke(sender, args);

        private static void OnPlaceholderPropertyChanged(object sender, object oldValue, object newValue)
        {
            if (sender is NumberEntry control && newValue is string newText)
            {
                control.Placeholder = newText;
            }
        }
        #endregion Placeholder


        public NumberEntry()
        {
            InitializeComponent();
            this.NumberChanged += this.OnNumberChanged;
            this.PlaceholderChanged += this.OnPlaceholderChanged;
            this.LabelChanged += this.OnLabelChanged;
        }
    }
}