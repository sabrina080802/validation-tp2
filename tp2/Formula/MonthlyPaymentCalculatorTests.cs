using CréditImmobilier.Data;
using CréditImmobilier.Formula;

namespace tp2.Formula;

public class MonthlyPaymentCalculatorTests
{
    [Fact]
    public void GetMonthlyPayment_ReturnsExpectedAmount_ForKnownScenario()
    {
        var formData = new FormData { capital = 175_000, duration = 25, rateType = RateType.GoodRate, insuranceRate = InsuranceRate.None };

        double monthlyPayment = MonthlyPaymentCalculator.GetMonthlyPayment(formData);

        Assert.Equal(671.48, monthlyPayment, 2);
    }

    [Fact]
    public void GetGlobalPaid_ReturnsExpectedTotal_ForKnownScenario()
    {
        var formData = new FormData { capital = 175_000, duration = 25, rateType = RateType.GoodRate, insuranceRate = InsuranceRate.None };

        double totalPaid = MonthlyPaymentCalculator.GetGlobalPaid(formData);

        Assert.Equal(201_443.26, totalPaid, 2);
    }

    [Fact]
    public void GetTotalInterestRefunded_ReturnsExpectedInterests_ForKnownScenario()
    {
        var formData = new FormData { capital = 175_000, duration = 25, rateType = RateType.GoodRate, insuranceRate = InsuranceRate.None };

        double totalInterests = MonthlyPaymentCalculator.GetTotalInterestRefunded(formData);

        Assert.Equal(26_443.26, totalInterests, 2);
    }
}
