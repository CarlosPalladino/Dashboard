using Apllication.Interfaces;
using Apllication.Records;

namespace Apllication.Services
{
    public class ProductService : IProducService
    {
        private readonly IProducService _repo;


        public ProductService(IProducService repo)
        {
            _repo = repo;
        }

        public Task<ProductRecords.ProductSummary> GetGeneralSummaryAsync()
        {
            var model = _repo.GetGeneralSummaryAsync();


            return model;
        }
    }
}
