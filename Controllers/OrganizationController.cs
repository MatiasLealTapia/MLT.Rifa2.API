using Microsoft.AspNetCore.Mvc;
using MLT.Rifa2.API.DTOs;
using MLT.Rifa2.API.Interfaces;
using MLT.Rifa2.API.Services;

namespace MLT.Rifa2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<OrganizationDTO>> Add([FromBody] OrganizationDTO organizationDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                return Ok(await _organizationService.Add(organizationDTO));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("{organizationId}")]
        public async Task<ActionResult<OrganizationDTO>> Get(int organizationId)
        {
            try
            {
                if (organizationId < 1)
                    return BadRequest();
                if (await _organizationService.Get(organizationId) == null)
                    return NotFound();
                return Ok(await _organizationService.Get(organizationId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<OrganizationDTO>> Update([FromBody] OrganizationDTO organizationDTO)
        {
            try
            {
                if (organizationDTO.OrganizationTypeId < 1)
                    return BadRequest();
                if (await _organizationService.Get(organizationDTO.OrganizationTypeId) == null)
                    return NotFound();
                return Ok(await _organizationService.Update(organizationDTO));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<OrganizationDTO>> Delete([FromBody] OrganizationDTO organizationDTO)
        {
            try
            {
                if (organizationDTO.OrganizationTypeId < 1)
                    return BadRequest();
                if (await _organizationService.Get(organizationDTO.OrganizationTypeId) == null)
                    return NotFound();
                return Ok(await _organizationService.Delete(organizationDTO));
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
                return Ok(await _organizationService.List());
            }
            catch (Exception ex)
            {

                return NotFound();
            }
        }
    }
}
