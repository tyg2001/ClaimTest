using ClaimProcessor.Models;
using ClaimProcessor.Repositories;
using System.Diagnostics;

namespace ClaimProcessor.Services
{
    public interface IClaimService
    {
        public Task<DrugPrice> Process(Claim claim);
        public Task<IList<Claim>> GetClaims();
    }
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IPriceService _priceService;
        public ClaimService(IClaimRepository claimRepository, IPriceService priceService) 
        {
            _claimRepository = claimRepository;
            _priceService = priceService;
        }
        
        public async Task<DrugPrice> Process(Claim claim) 
        {
            var price = await _priceService.GetPrice(claim.NDC);
            await _claimRepository.InsertClaim(claim);
            Guid newGuid = Guid.NewGuid();
            string guidString = newGuid.ToString();
            var drugprice = new DrugPrice() { ConfirmationNumber= guidString, Ndc = claim.NDC , Price = price.Price * claim.PlanRate };
            return drugprice;
        }
        public async Task<IList<Claim>> GetClaims()
        {
            return await _claimRepository.GetClaims();
           
        }
    }
}
