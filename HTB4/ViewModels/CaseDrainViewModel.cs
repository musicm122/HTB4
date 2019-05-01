using System.Threading.Tasks;
using CalculationLogic;
using HTB4.Services;
using Xamarin.Forms;
namespace HTB4.ViewModels
{
    public class CaseDrainViewModel : BaseCalculationViewModel
    {
        public CaseDrainViewModel()
        {
            CalculateCommand = new Command(() => Calculate());
            ClearCommand = new Command(() => Clear());
        }

        double rpm = 0;

        public double Rpm
        {
            get { return rpm; }
            set { SetProperty(ref rpm, value); }
        }

        double ccrev = 0;

        public double CCRev
        {
            get { return ccrev; }
            set { SetProperty(ref ccrev, value); }
        }

        double efficency = 0;

        public double Efficency
        {
            get { return efficency; }
            set { SetProperty(ref efficency, value); }
        }

        double ccMinOut = 0f;

        public double CCMinOut
        {
            get { return ccMinOut; }
            set { SetProperty(ref ccMinOut, value); }
        }

        double lMinOut = 0f;

        public double LMinOut
        {
            get { return lMinOut; }
            set { SetProperty(ref lMinOut, value); }
        }

        double areaOut = 0f;

        public double AreaOut
        {
            get { return areaOut; }
            set { SetProperty(ref areaOut, value); }
        }

        double distanceOut = 0f;

        public double DistanceOut
        {
            get { return distanceOut; }
            set { SetProperty(ref distanceOut, value); }
        }

        double secondOut = 0f;

        public double SecondOut
        {
            get { return secondOut; }
            set { SetProperty(ref secondOut, value); }
        }

        double gpmOut = 0f;

        public double GpmOut
        {
            get { return gpmOut; }
            set { SetProperty(ref gpmOut, value); }
        }

        public override void Calculate()
        {
            CCMinOut = CaseDrainCalculationService.CubicCentilitersPerMinute(rpm, ccrev, efficency);
            LMinOut = CaseDrainCalculationService.CubicLitersPerMinute(rpm, ccrev, efficency);
            GpmOut = CaseDrainCalculationService.CubicGallonsPerMinute(rpm, ccrev, efficency);
        }

        public override void Clear()
        {
            Rpm = 0;
            CCRev = 0;
            Efficency = 0;
            AreaOut = 0;
            DistanceOut = 0;
            SecondOut = 0;
            GpmOut = 0;
        }
    }
}