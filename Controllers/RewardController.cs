using Microsoft.AspNetCore.Mvc;
using MLT.Rifa2.API.DTOs;
using MLT.Rifa2.API.Interfaces;

namespace MLT.Rifa2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardController : ControllerBase
    {
        private readonly IRewardService _rewardService;

        public RewardController(IRewardService rewardService)
        {
            _rewardService = rewardService;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<RewardDTO>> Add([FromBody] RewardDTO rewardDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                return Ok(await _rewardService.Add(rewardDTO));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("{rewardId}")]
        public async Task<ActionResult<RewardDTO>> Get(int rewardId)
        {
            try
            {
                if (await _rewardService.Get(rewardId) == null)
                    return NotFound();
                return Ok(await _rewardService.Get(rewardId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<RewardDTO>> Update([FromBody] RewardDTO rewardDTO)
        {
            try
            {
                if (await _rewardService.Get(rewardDTO.RewardId) == null)
                    return NotFound();
                return Ok(await _rewardService.Update(rewardDTO));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<RewardDTO>> Delete([FromBody] RewardDTO rewardDTO)
        {
            try
            {
                if (await _rewardService.Get(rewardDTO.RewardId) == null)
                    return NotFound();
                return Ok(await _rewardService.Delete(rewardDTO));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<OrganizationDTO>> GetList()
        {
            try
            {
                return Ok(await _rewardService.List());
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
