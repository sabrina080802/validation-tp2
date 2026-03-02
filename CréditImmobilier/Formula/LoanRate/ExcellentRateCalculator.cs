namespace CréditImmobilier.Formula.LoanRate;

public class ExcellentRateCalculator : ILoanCalculator
{
    public double GetRateInPercent(int duration)
    {
        if (duration < 10)
            return 0.35;
        else if (duration < 15)
            return 0.45;
        else if (duration < 20)
            return 0.58;
        else if (duration < 25)
            return 0.73;
        else
            return 0.89;
    }
}