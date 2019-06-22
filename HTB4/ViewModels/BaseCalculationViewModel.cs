using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HTB4.ViewModels
{
    public class BaseCalculationViewModel : BaseViewModel
    {
        public BaseCalculationViewModel()
        {
            ClearCommand = new Command(() => Clear());

        }
        public ICommand ClearCommand { get; set; }

        public virtual void Clear() { }
    }
}