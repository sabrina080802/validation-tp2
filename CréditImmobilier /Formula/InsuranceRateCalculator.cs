using CréditImmobilier.Data;

namespace CréditImmobilier.Criteria;

static class InsuranceRateCalculator
{
    
    public static double CalculateRate(InsuranceRate insuranceRate){
        double defaultRate = 0.3;

        if (insuranceRate.HasFlag(InsuranceRate.IsAthletic)) defaultRate -= 0.05;
        if (insuranceRate.HasFlag(InsuranceRate.IsCardiac)) defaultRate += 0.3;
        if (insuranceRate.HasFlag(InsuranceRate.IsEngineerComputerScience)) defaultRate -= 0.05;
        if (insuranceRate.HasFlag(InsuranceRate.IsFighterPilot)) defaultRate += 0.15;
        if (insuranceRate.HasFlag(InsuranceRate.IsSmoker)) defaultRate += 0.15;
        
        return defaultRate;
    }    
}