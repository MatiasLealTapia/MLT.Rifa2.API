using Microsoft.AspNetCore.Mvc;
using MLT.Rifa2.API.DTOs;
using MLT.Rifa2.API.Interfaces;
using MLT.Rifa2.API.Services;

namespace MLT.Rifa2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        private readonly IGenericService _genericService;

        public GenericController(IGenericService genericService)
        {
            _genericService = genericService;
        }
        [HttpGet]
        [Route("GetOrganizationTypes")]
        public async Task<ActionResult<GenericItemDTO>> GetOrganizationTypes()
        {
            try
            {
                return Ok(await _genericService.GetOrganizationTypes());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("GetOrganizationType/{idObj}")]
        public async Task<ActionResult<GenericItemDTO>> GetOrganizationType(int idObj)
        {
            try
            {
                return Ok(await _genericService.GetOrganizationType(idObj));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("GetOrganizationsByType/{idType}")]
        public async Task<ActionResult<GenericItemDTO>> GetOrganizationsByType(int idType)
        {
            try
            {
                return Ok(await _genericService.GetOrganizationsByType(idType));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
