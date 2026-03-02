using CréditImmobilier.Data;

namespace CréditImmobilier.Interfaces
{
    public interface ILoanCriteriaValidator
    {
        bool IsValid(FormData formData);
    }
}
