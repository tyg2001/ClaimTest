using ClaimProcessor.Models;
using ClaimProcessor.Repositories;

namespace ClaimProcessor.Services
{
    public interface IPriceService
    {
        public Task<NdcPrice> GetPrice(string ndc);
    }
    public class PriceService: IPriceService
    {
        private INdcRepository _ndcRepository;
        public PriceService(INdcRepository ndcRepository) { _ndcRepository = ndcRepository; }

        public async Task<NdcPrice> GetPrice(string ndc)
        {
            return await _ndcRepository.GetPrice(ndc);
        }
    }
}
