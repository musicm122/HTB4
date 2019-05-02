using System.Threading.Tasks;
using System.Windows.Input;
using CalculationLogic;
using HTB4.Services;
using Xamarin.Forms;
namespace HTB4.ViewModels
{
    public class CaseDrainViewModel : BaseCalculationViewModel
    {
        public CaseDrainViewModel()
        {
            CalculateCaseDrainCommand = new Command(() => CalculateCaseDrain());
            CalculateCycleTimeCommand = new Command(() => CalculateCycleTimeForGPM());
            ClearCommand = new Command(() => Clear());
        }

        public ICommand CalculateCaseDrainCommand { get; set; }

        public ICommand CalculateCycleTimeCommand { get; set; }

        float rpm = 0;

        public float Rpm
        {
            get { return rpm; }
            set { SetProperty(ref rpm, value); }
        }

        float ccrev = 0;

        public float CCRev
        {
            get { return ccrev; }
            set { SetProperty(ref ccrev, value); }
        }

        float efficency = 0;

        public float Efficency
        {
            get { return efficency; }
            set { SetProperty(ref efficency, value); }
        }

        float ccMinOut = 0f;

        public float CCMinOut
        {
            get { return ccMinOut; }
            set { SetProperty(ref ccMinOut, value); }
        }

        float lMinOut = 0f;

        public float LMinOut
        {
            get { return lMinOut; }
            set { SetProperty(ref lMinOut, value); }
        }

        float area = 0f;

        public float Area
        {
            get { return area; }
            set { SetProperty(ref area, value); }
        }

        float distance = 0f;

        public float Distance
        {
            get { return distance; }
            set { SetProperty(ref distance, value); }
        }

        float second = 0f;

        public float Second
        {
            get { return second; }
            set { SetProperty(ref second, value); }
        }

        float gpmOut = 0f;

        public float GpmOut
        {
            get { return gpmOut; }
            set { SetProperty(ref gpmOut, value); }
        }

        public void CalculateCaseDrain()
        {
            CCMinOut = CaseDrain.CubicCentilitersPerMinute(rpm, ccrev, efficency);
            LMinOut = CaseDrain.CubicLitersPerMinute(rpm, ccrev, efficency);
            GpmOut = CaseDrain.CubicGallonsPerMinute(rpm, ccrev, efficency);
        }

        public void CalculateCycleTimeForGPM()
        {
            GpmOut = CaseDrain.CubicGallonsPerMinuteNeededForCycleTime(area, distance, second);
        }

        public override void Clear()
        {
            Rpm = 0;
            CCRev = 0;
            Efficency = 0;
            Area = 0;
            Distance = 0;
            Second = 0;
            GpmOut = 0;
        }
    }
}