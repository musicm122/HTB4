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
    public partial class ExpanderButton : ContentView
    {
        private static readonly Color DefaultTextColor = (Color)Application.Current.Resources["PrimaryText"];
        private static readonly Color DefaultButtonColor = (Color)Application.Current.Resources["Primary"];

        #region ButtonColor

        public static readonly BindableProperty ButtonColorProperty =
            BindableProperty.Create(
               "ButtonColor",
               typeof(Color),
               typeof(ExpanderButton),
               defaultValue: DefaultButtonColor,
               propertyChanged: OnButtonColorPropertyChanged);

        public Color ButtonColor
        {
            get => (Color)GetValue(ButtonColorProperty);
            set => this.SetValue(ButtonColorProperty, value);
        }

        private static void OnButtonColorPropertyChanged(object sender, object oldValue, object newValue)
        {
            if (sender is ExpanderButton control && newValue is Color newColor)
            {
                control.ButtonColor = newColor;
            }
        }
        #endregion ButtonColor

        #region TextColor

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(
               "TextColor",
               typeof(Color),
               typeof(ExpanderButton),
               defaultValue: DefaultTextColor,
               propertyChanged: OnTextColorPropertyChanged);

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => this.SetValue(TextColorProperty, value);
        }

        private static void OnTextColorPropertyChanged(object sender, object oldValue, object newValue)
        {
            if (sender is ExpanderButton control && newValue is Color newColor)
            {
                control.TextColor = newColor;
            }
        }
        #endregion TextColor

        #region Text
        public event EventHandler<TextChangedEventArgs> TextChanged = delegate { };

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(
               "Text",
               typeof(string),
               typeof(ExpanderButton),
               defaultValue: default(string),
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
            if (sender is ExpanderButton control && newValue is string newText)
            {
                control.Text = newText;
            }
        }
        #endregion Text

        #region Description
        public event EventHandler<TextChangedEventArgs> DescriptionChanged = delegate { };

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create(
               "Description",
               typeof(string),
               typeof(ExpanderButton),
               defaultValue: default(string),
               propertyChanged: OnDescriptionPropertyChanged);

        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => this.SetValue(DescriptionProperty, value);
        }

        protected virtual void OnDescriptionChanged(object sender, TextChangedEventArgs args) =>
            DescriptionChanged?.Invoke(sender, args);

        private static void OnDescriptionPropertyChanged(object sender, object oldValue, object newValue)
        {
            if (sender is ExpanderButton control && newValue is string newText)
            {
                control.Description = newText;
            }
        }
        #endregion Description

        #region IsExpanded

        public static readonly BindableProperty IsExpandedProperty =
            BindableProperty.Create(
               "IsExpanded",
               typeof(bool),
               typeof(ExpanderButton),
               defaultValue: false,
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: OnIsExpandedPropertyChanged);

        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => this.SetValue(IsExpandedProperty, value);
        }

        private static void OnIsExpandedPropertyChanged(object sender, object oldValue, object newValue)
        {
            if (sender is ExpanderButton control && newValue is bool newIsExpanded)
            {
                control.IsExpanded = newIsExpanded;
                control.Icon = control.IsExpanded ? FontConstants.ArrowDownBoldCircle : FontConstants.ArrowUpBoldCircle;
            }
        }

        #endregion IsExpanded

        #region Icon

        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(
               "Icon",
               typeof(string),
               typeof(ExpanderButton),
               defaultValue: FontConstants.ArrowUpBoldCircle,
               propertyChanged: OnIconPropertyChanged);

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => this.SetValue(IconProperty, value);
        }

        private static void OnIconPropertyChanged(object sender, object oldValue, object newValue)
        {

            if (sender is ExpanderButton control && newValue is string newIcon)
            {
                control.Icon = newIcon;
            }
        }
        #endregion Icon

        public ExpanderButton()
        {
            InitializeComponent();
        }
    }
}