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
        [HttpGet]
        [Route("GetOrganizations")]
        public async Task<ActionResult<GenericItemDTO>> GetOrganizations()
        {
            try
            {
                return Ok(await _genericService.GetOrganizations());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("GetOrganization/{idObj}")]
        public async Task<ActionResult<GenericItemDTO>> GetOrganization(int idObj)
        {
            try
            {
                return Ok(await _genericService.GetOrganization(idObj));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("GetReferents")]
        public async Task<ActionResult<GenericItemDTO>> GetReferents()
        {
            try
            {
                return Ok(await _genericService.GetReferents());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("GetReferent/{idObj}")]
        public async Task<ActionResult<GenericItemDTO>> GetReferent(int idObj)
        {
            try
            {
                return Ok(await _genericService.GetReferent(idObj));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("GetReferentByRut/{referentRut}")]
        public async Task<ActionResult<GenericItemDTO>> GetReferentByRut(int referentRut)
        {
            try
            {
                return Ok(await _genericService.GetReferentByRut(referentRut));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("GetReferentByEmail/{referentEmail}")]
        public async Task<ActionResult<GenericItemDTO>> GetReferentByEmail(string referentEmail)
        {
            try
            {
                return Ok(await _genericService.GetReferentByEmail(referentEmail));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("GetReferentsByOrganizationId/{organizationId}")]
        public async Task<ActionResult<GenericItemDTO>> GetReferentsByOrganizationId(int organizationId)
        {
            try
            {
                return Ok(await _genericService.GetReferentsByOrganizationId(organizationId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
