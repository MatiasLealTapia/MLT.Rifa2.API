using Microsoft.AspNetCore.Mvc;
using MLT.Rifa2.API.DTOs;
using MLT.Rifa2.API.Interfaces;
using MLT.Rifa2.API.Services;

namespace MLT.Rifa2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaffleController : ControllerBase
    {
        private readonly IRaffleService _raffleService;

        public RaffleController(IRaffleService raffleService)
        {
            _raffleService = raffleService;
        }

        [HttpPost]
        [Route("CreateRaffle")]
        public async Task<ActionResult<bool>> Add([FromBody] RaffleDTO raffleDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                return Ok(await _raffleService.CreateRaffle(raffleDTO));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetListByOrganization/{orgId}")]
        public async Task<IEnumerable<RaffleDTO>> GetListByOrganization(int orgId)
        {
            try
            {
                return await _raffleService.GetListByOrganization(orgId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
