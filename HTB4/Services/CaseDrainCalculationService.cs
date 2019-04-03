namespace HTB4.Services
{
    public static class CaseDrainCalculationService
    {
        public static float CubicCentilitersPerMinute(float rpm, float cubicCentimetersInRevolutions, float efficency) =>
            (rpm * cubicCentimetersInRevolutions) - (rpm * cubicCentimetersInRevolutions * efficency);

        public static float CubicLitersPerMinute(float rpm, float cubicCentimetersInRevolutions, float efficency) =>
            CubicCentilitersPerMinute(rpm, cubicCentimetersInRevolutions, efficency) / 1000f;

        public static float CubicGallonsPerMinute(float rpm, float cubicCentimetersInRevolutions, float efficency) =>
            CubicLitersPerMinute(rpm, cubicCentimetersInRevolutions, efficency) / 3.79f;
    }
}