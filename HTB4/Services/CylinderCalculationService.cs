namespace HTB4.Services
{
    public static class CylinderCalculationService
    {
        public static float Force(float area, float psi) =>
            area * psi;

        public static float PSI(float force, float area) =>
            force / area;

        public static float InchesPerSecond(float gpm, float area) =>
            (231f * gpm) / (60f * area);

    }
}