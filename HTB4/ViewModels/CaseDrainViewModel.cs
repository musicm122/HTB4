using System.Threading.Tasks;
using Xamarin.Forms;
namespace HTB4.ViewModels
{
    public class CaseDrainViewModel : BaseCalculationViewMode
    {
        public CaseDrainViewModel()
        {
            CalculateCommand = new Command(async () => await Calculate());
            ClearCommand = new Command(async () => await Clear());
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

        async Task Calculate()
        {
        }

        async Task Clear()
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