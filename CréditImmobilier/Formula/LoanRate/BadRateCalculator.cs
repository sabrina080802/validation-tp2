namespace CréditImmobilier.Formula.LoanRate;

public class BadRateCalculator : ILoanCalculator
{
    public double GetRateInPercent(int duration)
    {
        if (duration < 10)
            return 0.62;
        else if (duration < 15)
            return 0.67;
        else if (duration < 20)
            return 0.85;
        else if (duration < 25)
            return 1.04;
        else
            return 1.27;
    }
}