namespace CréditImmobilier.Components;

using CréditImmobilier.Data;
using CréditImmobilier.Formula;
using Microsoft.Maui.Graphics;

public partial class AmortizationTable : ContentView
{
    public AmortizationTable()
    {
        InitializeComponent();
    }

    public void GenerateAmortization(FormData formData)
    {
        List<AmortizationRow> amortizationSchedule = new List<AmortizationRow>();

        double monthlyRate = LoanRateCalculator.GetRate(formData.duration, formData.rateType) / 12;
        double monthlyPayment = MonthlyPaymentCalculator.GetMonthlyPayment(formData);
        double insurancePayment = InsuranceRateCalculator.GetMonthlyContributionInsurance(formData);
        double remainingBalance = formData.capital;
        double repaidCapital = 0;

        for (int month = 1; month <= formData.DurationInMonths; month++)
        {
            double interestPayment = remainingBalance * monthlyRate;
            double principalPayment = monthlyPayment - interestPayment;

            if (principalPayment > remainingBalance)
            {
                principalPayment = remainingBalance;
                monthlyPayment = principalPayment + interestPayment;
            }

            remainingBalance -= principalPayment;
            repaidCapital += principalPayment;

            if (remainingBalance < 0)
                remainingBalance = 0;

            amortizationSchedule.Add(new AmortizationRow
            {
                Month = month,
                Payment = Math.Round(monthlyPayment, 2),
                Interest = Math.Round(interestPayment, 2),
                Principal = Math.Round(principalPayment, 2),
                Insurance = Math.Round(insurancePayment, 2),
                RemainingBalance = Math.Round(remainingBalance, 2),
                RepaidCapital = Math.Round(repaidCapital, 2),
                RowBackground = month % 2 == 0 ? Color.FromArgb("#1B2738") : Color.FromArgb("#233247")
            });
        }

        AmortizationCollectionView.ItemsSource = amortizationSchedule;
    }
}
