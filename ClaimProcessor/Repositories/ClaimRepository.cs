using ClaimProcessor.Models;
using Microsoft.EntityFrameworkCore;

namespace ClaimProcessor.Repositories
{
    public interface IClaimRepository
    {
        public Task<IList<Claim>> GetClaims();
        public Task<Claim?> GetClaim(long id);
        public Task InsertClaim(Claim claim);
        public Task UpdateClaim(Claim claim);
    }
    public class ClaimRepository : IClaimRepository
    {
        private readonly IDbContextFactory<ClaimDBContext> _context;
        public ClaimRepository(IDbContextFactory<ClaimDBContext> context)
        {
            _context = context;
        }
        public async Task<IList<Claim>> GetClaims()
        {
            using (var context = await _context.CreateDbContextAsync())
            {
                return await context.Claims.ToListAsync();
            }
        }

        public async Task<Claim?> GetClaim(long id)
        {
            using (var context = await _context.CreateDbContextAsync())
            {
                return await context.Claims.FirstOrDefaultAsync();
            }
        }

        public async Task InsertClaim(Claim claim)
        {
            using (var context = await _context.CreateDbContextAsync())
            {
                await context.Claims.AddAsync(claim);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateClaim(Claim claim)
        {
            using (var context = await _context.CreateDbContextAsync())
            {
                var find = await context.Claims.FirstOrDefaultAsync(c=> c.Id == claim.Id);
                find.NDC= claim.NDC;
                find.MemberName = claim.MemberName;
                find.MemberId = claim.MemberId;
                find.MemberDOB = claim.MemberDOB;
                find.DOS = claim.DOS;
                context.Claims.Update(find);
            }
        }
    }
}
