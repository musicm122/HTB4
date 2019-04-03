using System;

namespace HTB4.Services
{
    public static class PumpCalculationService
    {
        public static float HPRequired(float gpm, float psi) =>
            gpm * psi * 0.0007f;

        public static float PumpOutputFlow(float rpm, float disp) =>
            (rpm * disp) / 231f;

        public static float DisplacementNeededForGPM(float rpm, float gpm) =>
            231f * gpm / rpm;
    }
}