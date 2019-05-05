using System;
using CalculationLogic;
using HTB4.Services;
using Xunit;

namespace HTB4.Tests
{
    public class CaseDrainCalculationServiceTests
    {
        [Theory]
        [InlineData(2d, 2d, 2d, -4d)]
        [InlineData(2d, 2d, 1d, 0d)]
        [InlineData(2d, 2d, 10d, -36d)]
        [InlineData(2d, 2d, 100d, -396d)]
        public void CubicCentilitersPerMinute(float rpm, float cubicCentimetersInRevolutions, float efficency, float expected)
        {
            var actual = CaseDrain.CubicCentilitersPerMinute(rpm, cubicCentimetersInRevolutions, efficency);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2d, 2d, 2d, -4d)]
        [InlineData(2d, 2d, 1d, 0d)]
        [InlineData(2d, 2d, 10d, -0.04d)]
        [InlineData(2d, 2d, 100d, -0.40d)]
        public void CubicLitersPerMinute(float rpm, float cubicCentimetersInRevolutions, float efficency, float expected)
        {
            var actual = CaseDrain.CubicLitersPerMinute(rpm, cubicCentimetersInRevolutions, efficency);
            Assert.Equal(expected, actual);
        }

    }
}
