using CréditImmobilier.Data;
using CréditImmobilier.Interfaces;

namespace CréditImmobilier;

public partial class MainPage : ContentPage
{
    private readonly ILoanCriteriaValidator _loanCriteriaValidator;
    private readonly ILoanStatisticsService _loanStatisticsService;

    public MainPage(ILoanCriteriaValidator loanCriteriaValidator, ILoanStatisticsService loanStatisticsService)
    {
        _loanCriteriaValidator = loanCriteriaValidator;
        _loanStatisticsService = loanStatisticsService;
        InitializeComponent();
    }

    private InsuranceRate GetInsuranceRate()
    {
        InsuranceRate rate = InsuranceRate.None;
        if (SportifCheck.IsChecked) rate |= InsuranceRate.IsAthletic;
        if (FumeurCheck.IsChecked) rate |= InsuranceRate.IsSmoker;
        if (CardiacCheck.IsChecked) rate |= InsuranceRate.IsCardiac;
        if (EngineerCheck.IsChecked) rate |= InsuranceRate.IsEngineerComputerScience;
        if (PilotCheck.IsChecked) rate |= InsuranceRate.IsFighterPilot;

        return rate;
    }

    private bool TryCreateFormData(out FormData result)
    {
        result = default;
        if (!double.TryParse(CapitalEntry.Text, out result.capital))
            return false;

        if (!int.TryParse(DurationEntry.Text, out result.duration))
            return false;

        if (!Enum.TryParse(RatePicker.SelectedItem?.ToString(), out result.rateType))
            return false;

        result.insuranceRate = GetInsuranceRate();
        return true;
    }

    private void OnCalculateClicked(object sender, EventArgs e)
    {
        FormData formData;
        if (!TryCreateFormData(out formData) || !_loanCriteriaValidator.IsValid(formData))
        {
            ResultLabel.Text = "Les valeurs d'emprunt sont invalides";
            return;
        }

        LoanStatistics statistics = _loanStatisticsService.GetStatistics(formData);
        ResultLabel.Text =
            $"Montant global de la mensualité : {statistics.totalMonthlyAmount}€\n" +
            $"Montant de la cotisation mensuelle d'assurance : {statistics.insurance} €\n" +
            $"Montant total des intérêts remboursés : {statistics.totalInterestRefunded} €\n" +
            $"Montant total de l'assurance : {statistics.totalInsurance}€\n" +
            $"Montant du capital remboursé au bout de 10 ans : {statistics.refundedCapitalAfterTenYears}€";

        AmortizationTableComponent.GenerateAmortization(formData);
    }
}
