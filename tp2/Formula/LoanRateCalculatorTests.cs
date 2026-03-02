using CréditImmobilier.Data;
using CréditImmobilier.Formula;

namespace tp2.Formula;

public class LoanRateCalculatorTests
{
    [Fact]
    public void GetRate_ReturnsExpectedAnnualRate_ForGoodRateAnd25Years()
    {
        double rate = LoanRateCalculator.GetRate(25, RateType.GoodRate);

        Assert.Equal(0.0115, rate, 6);
    }

    [Fact]
    public void GetCapitalRefundedAfterYears_ReturnsExpectedAmount_After10Years()
    {
        var formData = new FormData { capital = 175_000, duration = 25, rateType = RateType.GoodRate, insuranceRate = InsuranceRate.None };

        double refundedCapital = LoanRateCalculator.GetCapitalRefundedAfterYears(formData, 10);

        Assert.Equal(64_033.00, refundedCapital, 2);
    }
}
