using CréditImmobilier.Data;
using CréditImmobilier.Services;

namespace tp2.Criteria;

public class LoanCriteriaTests
{
    private readonly LoanCriteriaService _service = new();

    [Fact]
    public void IsValid_ReturnsTrue_ForValidData()
    {
        var formData = new FormData { capital = 175_000, duration = 25, rateType = RateType.GoodRate };

        bool isValid = _service.IsValid(formData);

        Assert.True(isValid);
    }

    [Fact]
    public void IsValid_ReturnsFalse_WhenCapitalIsTooLow()
    {
        var formData = new FormData { capital = 50_000, duration = 20, rateType = RateType.GoodRate };

        bool isValid = _service.IsValid(formData);

        Assert.False(isValid);
    }

    [Theory]
    [InlineData(8)]
    [InlineData(27)]
    public void IsValid_ReturnsFalse_WhenDurationOutOfRange(int duration)
    {
        var formData = new FormData { capital = 120_000, duration = duration, rateType = RateType.GoodRate };

        bool isValid = _service.IsValid(formData);

        Assert.False(isValid);
    }
}
