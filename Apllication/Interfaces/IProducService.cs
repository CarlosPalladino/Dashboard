using static Apllication.Records.ProductRecords;

namespace Apllication.Interfaces
{
    public interface IProducService
    {
        Task<ProductSummary> GetGeneralSummaryAsync();
    }
}
