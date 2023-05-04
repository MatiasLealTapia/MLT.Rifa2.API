using Microsoft.AspNetCore.Mvc;
using MLT.Rifa2.API.DTOs;
using MLT.Rifa2.API.Interfaces;
using MLT.Rifa2.API.Models;
using MLT.Rifa2.API.Services;

namespace MLT.Rifa2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferentController : ControllerBase
    {
        private readonly IReferentService _referentService;

        public ReferentController(IReferentService referentService)
        {
            _referentService = referentService;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<ReferentDTO>> Add([FromBody] ReferentDTO referentDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                return Ok(await _referentService.Add(referentDTO));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("{referentId}")]
        public async Task<ActionResult<ReferentDTO>> Get(int referentId)
        {
            try
            {
                if (referentId < 1)
                    return BadRequest();
                if (await _referentService.Get(referentId) == null)
                    return NotFound();
                return Ok(await _referentService.Get(referentId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("GetByRut/{referentRut}")]
        public async Task<ActionResult<ReferentDTO>> GetByRut(int referentRut)
        {
            try
            {
                if (referentRut < 100000)
                    return BadRequest();
                var getObj = await _referentService.GetByRut(referentRut);
                if (getObj == null)
                    return NotFound();
                return Ok(getObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<ReferentDTO>> Update([FromBody] ReferentDTO referentDTO)
        {
            try
            {
                if (referentDTO.OrganizationId < 1)
                    return BadRequest();
                if (await _referentService.Get(referentDTO.OrganizationId) == null)
                    return NotFound();
                return Ok(await _referentService.Update(referentDTO));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<ReferentDTO>> Delete([FromBody] ReferentDTO referentDTO)
        {
            try
            {
                if (referentDTO.OrganizationId < 1)
                    return BadRequest();
                if (await _referentService.Get(referentDTO.OrganizationId) == null)
                    return NotFound();
                return Ok(await _referentService.Delete(referentDTO));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<ReferentDTO>> GetList()
        {
            try
            {
                return Ok(await _referentService.List());
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
