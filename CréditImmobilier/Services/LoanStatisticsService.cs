using CréditImmobilier.Data;
using CréditImmobilier.Formula;
using CréditImmobilier.Interfaces;

namespace CréditImmobilier.Services
{
    internal class LoanStatisticsService : ILoanStatisticsService
    {
        public LoanStatistics GetStatistics(FormData formData)
            => new LoanStatistics()
            {
                insurance = Math.Round(InsuranceRateCalculator.GetMonthlyContributionInsurance(formData), 2),
                totalMonthlyAmount = Math.Round(MonthlyPaymentCalculator.GetGlobalPaid(formData), 2),
                totalInterestRefunded = Math.Round(MonthlyPaymentCalculator.GetTotalInterestRefunded(formData), 2),
                totalInsurance = Math.Round(InsuranceRateCalculator.GetTotalInsuranceAmount(formData), 2),
                refundedCapitalAfterTenYears = Math.Round(LoanRateCalculator.GetCapitalRefundedAfterYears(formData, 10), 2)
            };
    }
}
