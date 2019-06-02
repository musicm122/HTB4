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
    public partial class OutputItemView : ContentView
    {
        private static readonly Color DefaultTextColor = (Color)Application.Current.Resources["OutputTextColor"];

        #region Text
        public event EventHandler<TextChangedEventArgs> TextChanged = delegate { };

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(
               "Text",
               typeof(string),
               typeof(OutputItemView),
               defaultValue: default(string),
               defaultBindingMode: BindingMode.TwoWay,
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
            if (sender is OutputItemView control && newValue is string newText)
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
               typeof(OutputItemView),
               defaultValue: default(string),
               defaultBindingMode: BindingMode.TwoWay,
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
            if (sender is OutputItemView control && newValue is string newText)
            {
                control.Description = newText;
            }
        }
        #endregion Description


        #region Label
        public event EventHandler<TextChangedEventArgs> LabelChanged = delegate { };

        public static readonly BindableProperty LabelProperty =
            BindableProperty.Create(
               "Label",
               typeof(string),
               typeof(OutputItemView),
               defaultValue: default(string),
               defaultBindingMode: BindingMode.TwoWay,
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
            if (sender is OutputItemView control && newValue is string newLabel)
            {
                control.Label = newLabel;
            }
        }
        #endregion Label

        #region TextColor

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(
               "TextColor",
               typeof(Color),
               typeof(OutputItemView),
               defaultValue: DefaultTextColor,
               propertyChanged: OnTextColorPropertyChanged);

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => this.SetValue(TextColorProperty, value);
        }


        private static void OnTextColorPropertyChanged(object sender, object oldValue, object newValue)
        {
            if (sender is OutputItemView control && newValue is Color newColor)
            {
                control.TextColor = newColor;
            }
        }
        #endregion TextColor

        public OutputItemView()
        {
            InitializeComponent();
        }
    }
}