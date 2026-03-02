using CréditImmobilier.Data;
using CréditImmobilier.Formula.LoanRate;

namespace CréditImmobilier.Formula;

static class LoanRateCalculator
{
    private static Dictionary<RateType, ILoanCalculator> calculators = new()
    {
        { RateType.BadRate, new BadRateCalculator() },
        { RateType.GoodRate, new GoodRateCalculator() },
        { RateType.ExcellentRate, new ExcellentRateCalculator() }
    };

    public static double GetCapitalRefundedAfterYears(FormData formData, int passedYears)
    {
        int passedMonths = passedYears * 12;
        double mensualRate = GetRate(formData.duration, formData.rateType) / 12;
        double monthlyPayment = MonthlyPaymentCalculator.GetMonthlyPayment(formData);

        double passedMonthInterests = Math.Pow(1 + mensualRate, passedMonths);
        double dueCapital = formData.capital * passedMonthInterests
                            - monthlyPayment * ((passedMonthInterests - 1) / mensualRate);

        return Math.Round(formData.capital - dueCapital, 2);
    }

    public static double GetRate(int duration, RateType rateType)
        => calculators[rateType].GetRateInPercent(duration) / 100;
}