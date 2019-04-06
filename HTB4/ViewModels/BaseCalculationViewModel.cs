using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HTB4.ViewModels
{
    public class BaseCalculationViewModel : BaseViewModel
    {
        public BaseCalculationViewModel()
        {
            CalculateCommand = new Command(() => Calculate());
            ClearCommand = new Command(() => Clear());

        }
        public ICommand CalculateCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public virtual void Calculate() { }
        public virtual void Clear() { }
    }
}