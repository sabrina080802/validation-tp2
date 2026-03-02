namespace CréditImmobilier.Formula.LoanRate;

public class GoodRateCalculator : ILoanCalculator
{
    public double GetRateInPercent(int duration)
    {
        if (duration < 10)
            return 0.43;
        else if (duration < 15)
            return 0.55;
        else if (duration < 20)
            return 0.873;
        else if (duration < 25)
            return 0.91;
        else
            return 1.15;
    }
}