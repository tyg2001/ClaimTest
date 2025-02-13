using AutoMapper;
using ClaimProcessor.DTOs;
using ClaimProcessor.Models;
using ClaimProcessor.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClaimProcessor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimService _claimService;
        private readonly IMapper _mapper;
        public ClaimController(IClaimService claimService, IMapper mapper)
        {
            _mapper = mapper;
            _claimService = claimService;
        }

        [HttpPost(Name = "ProcessClaim")]
        public async Task<ActionResult<DrugPriceDTO>> ProcessClaim([FromBody] ClaimDTO claim)
        {
            try
            {
                return Ok(_mapper.Map<DrugPriceDTO>(await _claimService.Process(_mapper.Map<Claim>(claim))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet()]
        public async Task<ActionResult<IList<ClaimDTO>>> GetClaims()
        {
            try
            {
                return Ok(_mapper.Map<IList<Claim>>((await _claimService.GetClaims())));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
