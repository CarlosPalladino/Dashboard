using static Apllication.Records.ProductRecord;

namespace Apllication.Interfaces.Services
{
    public interface IProducService
    {
        Task<ProductSummary> GetGeneralSummaryAsync();
    }
}
