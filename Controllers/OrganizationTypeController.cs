using Microsoft.AspNetCore.Mvc;
using MLT.Rifa2.API.DTOs;
using MLT.Rifa2.API.Interfaces;

namespace MLT.Rifa2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationTypeController : Controller
    {
        private readonly IOrganizationTypeService _organizationTypeService;
        public OrganizationTypeController(IOrganizationTypeService organizationTypeService)
        {
            _organizationTypeService = organizationTypeService;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<OrganizationTypeDTO>> Add([FromBody] OrganizationTypeDTO organizationTypeDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                return Ok(await _organizationTypeService.Add(organizationTypeDTO));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("{organizationTypeId}")]
        public async Task<ActionResult<OrganizationTypeDTO>> Get(int organizationTypeId)
        {
            try
            {
                if (organizationTypeId < 1)
                    return BadRequest();
                if (await _organizationTypeService.Get(organizationTypeId) == null)
                    return NotFound();
                return Ok(await _organizationTypeService.Get(organizationTypeId));
            }
            catch (Exception ex)
            {

                return NotFound();
            }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<OrganizationTypeDTO>> Update([FromBody] OrganizationTypeDTO organizationTypeDTO)
        {
            try
            {
                if (organizationTypeDTO.OrganizationTypeId < 1)
                    return BadRequest();
                if (await _organizationTypeService.Get(organizationTypeDTO.OrganizationTypeId) == null)
                    return NotFound();
                return Ok(await _organizationTypeService.Update(organizationTypeDTO));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<OrganizationTypeDTO>> Delete([FromBody] OrganizationTypeDTO organizationTypeDTO)
        {
            try
            {
                if (organizationTypeDTO.OrganizationTypeId < 1)
                    return BadRequest();
                if (await _organizationTypeService.Get(organizationTypeDTO.OrganizationTypeId) == null)
                    return NotFound();
                return Ok(await _organizationTypeService.Delete(organizationTypeDTO));
            }
            catch (Exception ex)
            {

                return NotFound();
            }
        }
        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<OrganizationTypeDTO>> GetList()
        {
            try
            {
                return Ok(await _organizationTypeService.List());
            }
            catch (Exception ex)
            {

                return NotFound();
            }
        }
    }
}
