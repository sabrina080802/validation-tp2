using CréditImmobilier.Data;
using CréditImmobilier.Formula;

namespace tp2.Formula;

public class InsuranceRateCalculatorTests
{
    [Fact]
    public void GetMonthlyRate_ReturnsBaseRate_WhenNoFlag()
    {
        double rate = InsuranceRateCalculator.GetMonthlyRate(InsuranceRate.None);

        Assert.Equal(0.003, rate, 6);
    }

    [Fact]
    public void GetMonthlyRate_ReturnsExpectedRate_WhenMultipleFlags()
    {
        InsuranceRate flags = InsuranceRate.IsAthletic | InsuranceRate.IsSmoker;

        double rate = InsuranceRateCalculator.GetMonthlyRate(flags);

        Assert.Equal(0.004, rate, 6);
    }

    [Theory]
    [InlineData(120_000, 20, RateType.GoodRate, 30)]
    [InlineData(250_000, 20, RateType.BadRate, 62.5)]
    public void GetMonthlyContributionInsurance_ReturnsExpectedAmount(double capital, int duration, RateType rateType, double expected)
    {
        FormData formData = new FormData
        {
            capital = capital,
            duration = duration,
            insuranceRate = InsuranceRate.None,
            rateType = rateType
        };

        double contribution = InsuranceRateCalculator.GetMonthlyContributionInsurance(formData);

        Assert.Equal(expected, contribution, 2);
    }

    [Theory]
    [InlineData(120_000, 20, RateType.GoodRate, 7200)]
    [InlineData(250_000, 20, RateType.BadRate, 15000)]
    public void GetTotalInsuranceAmount_ReturnsMonthlyContribution_MultipliedByDuration(double capital, int duration, RateType rateType, double expected)
    {
        FormData formData = new FormData
        {
            capital = capital,
            duration = duration,
            insuranceRate = InsuranceRate.None,
            rateType = rateType
        };
        double totalInsurance = InsuranceRateCalculator.GetTotalInsuranceAmount(formData);

        Assert.Equal(expected, totalInsurance, 2);
    }
}
