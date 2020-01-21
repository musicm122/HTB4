using CalculationLogic.ViewModels;

namespace HTB4.ViewModels.DesignTimeViewModels
{
    public static class DesignTimeViewModels
    {
        public static CaseDrainViewModel GetCaseDrainVM() =>
            new CaseDrainViewModel
            {
                Rpm = 0.0m,
                CCRev = 0.0m,
                Efficency = 0.0m,
                CCMinOut = 0.0m,
                LMinOut = 0.0m,
                CaseDrainGpmOut = 0.0m,
            };
    }
}