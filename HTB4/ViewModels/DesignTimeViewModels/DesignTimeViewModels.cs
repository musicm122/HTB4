using CalculationLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HTB4.ViewModels.DesignTimeViewModels
{
    public static class DesignTimeViewModels
    {
        public static CaseDrainViewModel GetCaseDrainVM() =>
            new CaseDrainViewModel
            {
                Rpm = 0.0f,
                CCRev = 0.0f,
                Efficency = 0.0f,
                CCMinOut = 0.0f,
                LMinOut = 0.0f,
                CaseDrainGpmOut = 0.0f,
                Area = 0.0f,
                Distance = 0.0f,
                Second = 0.0f,
                CycleTimeGpmOut = 0.0f
            };

    }
}
