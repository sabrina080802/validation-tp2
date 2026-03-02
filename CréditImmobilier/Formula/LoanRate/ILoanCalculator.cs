namespace CréditImmobilier.Formula.LoanRate;

public interface ILoanCalculator
{
    double GetRateInPercent(int duration);
}