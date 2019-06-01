using System;
using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class CalculationControl : ContentView
    {
        private static readonly Color DefaultCalculateColor = (Color)Application.Current.Resources["Primary"];
        private static readonly Color DefaultClearColor = (Color)Application.Current.Resources["Accent"];
        private static readonly Color DefaultCalculateTextColor = (Color)Application.Current.Resources["LightTextColor"];
        private static readonly Color DefaultClearTextColor = (Color)Application.Current.Resources["LightTextColor"];

        public event EventHandler CalculateClicked = delegate { };

        public event EventHandler ClearClicked = delegate { };

        public event EventHandler<TextChangedEventArgs> CalculateButtonTextChanged = delegate { };

        public static readonly BindableProperty CanCalculateProperty =
            BindableProperty.Create(
                "CanCalculate",
                typeof(bool),
                typeof(CalculationControl));

        public static readonly BindableProperty CalculateButtonColorProperty =
            BindableProperty.Create(
                "CalculateButtonColor",
                typeof(Color),
                typeof(CalculationControl),
                defaultValue: DefaultCalculateColor);

        public static readonly BindableProperty CalculateCommandProperty =
           BindableProperty.Create(
               "CalculateCommand",
               typeof(ICommand),
               typeof(CalculationControl),
               propertyChanged: CalculateCommandUpdated);

        public static readonly BindableProperty CalculateButtonColorTextProperty =
            BindableProperty.Create(
                "CalculateButtonTextColor",
                typeof(Color),
                typeof(CalculationControl),
                defaultValue: DefaultCalculateTextColor);

        public static readonly BindableProperty CalculateButtonTextProperty =
            BindableProperty.Create(
                "CalculateButtonText",
                typeof(string),
                typeof(CalculationControl),
                propertyChanged: OnCalculateButtonTextChanged,
                defaultValue: "Calculate");

        public static readonly BindableProperty ClearButtonColorProperty =
            BindableProperty.Create(
                "ClearButtonColor",
                typeof(Color),
                typeof(CalculationControl),
                defaultValue: DefaultClearColor);

        public static readonly BindableProperty ClearButtonColorTextProperty =
            BindableProperty.Create(
                "ClearButtonTextColor",
                typeof(Color),
                typeof(CalculationControl),
                defaultValue: DefaultClearTextColor);

        public static readonly BindableProperty ClearCommandProperty =
           BindableProperty.Create(
               "ClearCommand",
               typeof(ICommand),
               typeof(CalculationControl),
               propertyChanged: ClearCommandUpdated);

        public ICommand CalculateCommand
        {
            get => (ICommand)GetValue(CalculateCommandProperty);
            set => SetValue(CalculateCommandProperty, value);
        }

        public ICommand ClearCommand
        {
            get => (ICommand)GetValue(ClearCommandProperty);
            set => SetValue(ClearCommandProperty, value);
        }

        public bool CanCalculate
        {
            get => (bool)this.GetValue(CanCalculateProperty);
            set => this.SetValue(CalculateButtonColorProperty, value);
        }

        public Color CalculateButtonColor
        {
            get => (Color)this.GetValue(CalculateButtonColorProperty);
            set => this.SetValue(CalculateButtonColorProperty, value);
        }

        public Color CalculateButtonTextColor
        {
            get => (Color)this.GetValue(CalculateButtonColorTextProperty);
            set => this.SetValue(CalculateButtonColorTextProperty, value);
        }

        public string CalculateButtonText
        {
            get => (string)GetValue(CalculateButtonTextProperty);
            set => this.SetValue(CalculateButtonTextProperty, value);
        }

        public Color ClearButtonColor
        {
            get => (Color)this.GetValue(ClearButtonColorProperty);
            set => this.SetValue(ClearButtonColorProperty, value);
        }

        public Color ClearButtonTextColor
        {
            get => (Color)this.GetValue(ClearButtonColorTextProperty);
            set => this.SetValue(ClearButtonColorTextProperty, value);
        }

        public CalculationControl()
        {
            InitializeComponent();
            this.CalculateClicked += this.OnCalculateClicked;
            this.ClearClicked += this.OnClearClicked;
            this.CalculateButtonTextChanged += CalculationControl_CalculateButtonTextChanged;
        }

        private void CalculationControl_CalculateButtonTextChanged(object sender, TextChangedEventArgs args)
        {
            CalculateButtonTextChanged?.Invoke(this, args);
        }

        private void OnCalculateClicked(object sender, EventArgs args)
        {
            if (CalculateCommand == null) return;
            if (CalculateCommand.CanExecute(CanCalculate))
            {
                CalculateCommand.Execute(null);
            }
            //this.CalculateClicked?.Invoke(sender, args);
        }

        private void OnClearClicked(object sender, EventArgs args)
        {
            if (ClearCommand == null) return;

            ClearCommand.Execute(null);

            //this.CalculateClicked?.Invoke(sender, args);
        }

        private static void CalculateCommandUpdated(object sender, object oldValue, object newValue)
        {
            if (sender is CalculationControl control && newValue is ICommand newCommand)
            {
                control.CalculateCommand = newCommand;
            }
        }

        private static void OnCalculateButtonTextChanged(object sender, object oldValue, object newValue)
        {
            if (sender is CalculationControl control && newValue is string newText)
            {
                control.CalculateButtonText = newText;
            }
        }

        private static void ClearCommandUpdated(object sender, object oldValue, object newValue)
        {
            if (sender is CalculationControl control && newValue is ICommand newCommand)
            {
                control.ClearCommand = newCommand;
            }
        }
    }
}