using System.Threading.Tasks;
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

        float areaOut = 0f;

        public float AreaOut
        {
            get { return areaOut; }
            set { SetProperty(ref areaOut, value); }
        }

        float distanceOut = 0f;

        public float DistanceOut
        {
            get { return distanceOut; }
            set { SetProperty(ref distanceOut, value); }
        }

        float secondOut = 0f;

        public float SecondOut
        {
            get { return secondOut; }
            set { SetProperty(ref secondOut, value); }
        }

        float gpmOut = 0f;

        public float GpmOut
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