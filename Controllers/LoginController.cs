using Microsoft.AspNetCore.Mvc;
using MLT.Rifa2.API.DTOs;
using MLT.Rifa2.API.Interfaces;

namespace MLT.Rifa2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IOrganizationFormService _organizationFormService;

        public LoginController(IOrganizationFormService organizationFormService)
        {
            _organizationFormService = organizationFormService;
        }

        [HttpPost]
        [Route("PostOrganizationForm")]
        public Task<String> PostOrganizationForm(OrganizationFormDTO model)
        {
            try
            {
                var response = _organizationFormService.Add(model);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
