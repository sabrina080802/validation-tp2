using CréditImmobilier.Data;
using CréditImmobilier.Interfaces;

namespace CréditImmobilier.Services;

public class LoanCriteriaService : ILoanCriteriaValidator
{
    public bool IsValid(FormData formData)
    {
        if (formData.capital <= 50_000)
            return false;

        if (formData.duration < 9 || formData.duration > 26)
            return false;

        return true;
    }
}