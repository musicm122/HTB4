namespace HTB4.Services
{
    public static class CaseDrainCalculationService
    {
        public static double CubicCentilitersPerMinute(double rpm, double cubicCentimetersInRevolutions, double efficency) =>
            (rpm * cubicCentimetersInRevolutions) - (rpm * cubicCentimetersInRevolutions * efficency);

        public static double CubicLitersPerMinute(double rpm, double cubicCentimetersInRevolutions, double efficency) =>
            CubicCentilitersPerMinute(rpm, cubicCentimetersInRevolutions, efficency) / 1000d;

        public static double CubicGallonsPerMinute(double rpm, double cubicCentimetersInRevolutions, double efficency) =>
            CubicLitersPerMinute(rpm, cubicCentimetersInRevolutions, efficency) / 3.79d;
    }
}