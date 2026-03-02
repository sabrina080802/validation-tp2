using CréditImmobilier.Criteria.LoanRate;
using CréditImmobilier.Data;

namespace CréditImmobilier.Criteria;

static class LoanRateCalculator
{
    private static Dictionary<RateType, ILoanCalculator> calculators = new()
    {
        { RateType.BadRate, new BadRateCalculator() },
        { RateType.GoodRate, new GoodRateCalculator() },
        { RateType.ExcellentRate, new ExcellentRateCalculator() }
    };
    
    public static double CalculateRate(int duration, RateType rateType)
        => calculators[rateType].CalculateRate(duration);
}