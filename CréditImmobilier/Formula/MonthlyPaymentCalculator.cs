using CréditImmobilier.Data;

namespace CréditImmobilier.Formula;

public class MonthlyPaymentCalculator
{
    public static double GetMonthlyPayment(FormData formData)
    {
        double monthlyRate = LoanRateCalculator.GetRate(formData.duration, formData.rateType) / 12;
        
        return (formData.capital * monthlyRate) /
            (1 - Math.Pow((1 + monthlyRate), -formData.DurationInMonths));
    }
    
    public static double GetGlobalPaid(FormData formData)
        => GetMonthlyPayment(formData) * formData.DurationInMonths;

    public static double GetTotalInterestRefunded(FormData formData)
        => (GetMonthlyPayment(formData) * formData.DurationInMonths) - formData.capital;
}