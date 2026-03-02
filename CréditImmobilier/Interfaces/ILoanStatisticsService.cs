using CréditImmobilier.Data;

namespace CréditImmobilier.Interfaces
{
    public interface ILoanStatisticsService
    {
        LoanStatistics GetStatistics(FormData formData);
    }
}
