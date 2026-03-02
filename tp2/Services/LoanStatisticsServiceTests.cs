using CréditImmobilier.Data;
using CréditImmobilier.Services;

namespace tp2.Services;

public class LoanStatisticsServiceTests
{
    private readonly LoanStatisticsService _service = new();

    [Fact]
    public void GetStatistics_ReturnsExpectedRoundedValues_ForKnownScenario()
    {
        var formData = new FormData
        {
            capital = 175_000,
            duration = 25,
            rateType = RateType.GoodRate,
            insuranceRate = InsuranceRate.None
        };

        LoanStatistics stats = _service.GetStatistics(formData);

        Assert.Equal(43.75, stats.insurance, 2);
        Assert.Equal(201_443.26, stats.totalMonthlyAmount, 2);
        Assert.Equal(26_443.26, stats.totalInterestRefunded, 2);
        Assert.Equal(13_125.00, stats.totalInsurance, 2);
        Assert.Equal(64_033.00, stats.refundedCapitalAfterTenYears, 2);
    }
}
