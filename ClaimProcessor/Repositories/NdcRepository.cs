using ClaimProcessor.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ClaimProcessor.Repositories
{
    public interface INdcRepository
    {
        public Task<NdcPrice> GetPrice(string ndc);
    }
    public class NdcRepository : INdcRepository
    {
        private readonly IDbContextFactory<ClaimDBContext> _context;
        public NdcRepository(IDbContextFactory<ClaimDBContext> context)
        {
            _context = context;
        }
        public async Task<NdcPrice> GetPrice(string ndc)
        {
            using (var context = await _context.CreateDbContextAsync())
            {
                return await context.NdcPrices.FirstOrDefaultAsync(n=> n.Ndc == ndc);
            }
        }
    }

}
