namespace HTB4.Services
{
    public static class MotorCalculationService
    {
        public static float GPM(float diameter, float rpm) =>
            diameter * rpm / 231f;

        public static float MotorSpeed(float gpm, float disp) =>
            (231f * gpm) / disp;

        public static float FluidMotorTorque(float psi, float disp) =>
            (psi * disp) / 6.28f;

        public static float TorqueFromHP(float hp, float rpm) =>
            (hp * 63025f) / rpm;

        public static float TorqueFromGPM(float gpm, float psi, float rpm) =>
            gpm * psi * 36.7f / rpm;

        public static float VelocityOfFluid(float gpm, float id) =>
            (0.3208f * gpm) / id;
    }
}