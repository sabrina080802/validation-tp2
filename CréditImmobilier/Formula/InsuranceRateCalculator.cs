using CréditImmobilier.Data;

namespace CréditImmobilier.Formula;

static class InsuranceRateCalculator
{
    public static double GetMonthlyRate(InsuranceRate insuranceRate){
        double defaultRate = 0.3;

        if (insuranceRate.HasFlag(InsuranceRate.IsAthletic)) defaultRate -= 0.05;
        if (insuranceRate.HasFlag(InsuranceRate.IsCardiac)) defaultRate += 0.3;
        if (insuranceRate.HasFlag(InsuranceRate.IsEngineerComputerScience)) defaultRate -= 0.05;
        if (insuranceRate.HasFlag(InsuranceRate.IsFighterPilot)) defaultRate += 0.15;
        if (insuranceRate.HasFlag(InsuranceRate.IsSmoker)) defaultRate += 0.15;
        
        return defaultRate / 100;
    }

    public static double GetMonthlyContributionInsurance(FormData formData)
        => (formData.capital * GetMonthlyRate(formData.insuranceRate)) / 12;

    public static double GetTotalInsuranceAmount(FormData formData)
        => GetMonthlyContributionInsurance(formData) * formData.DurationInMonths;
}
