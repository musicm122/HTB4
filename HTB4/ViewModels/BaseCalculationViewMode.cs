using System.Windows.Input;

namespace HTB4.ViewModels
{
    public class BaseCalculationViewMode : BaseViewModel
    {
        public ICommand CalculateCommand { get; set; }
        public ICommand ClearCommand { get; set; }
    }
}