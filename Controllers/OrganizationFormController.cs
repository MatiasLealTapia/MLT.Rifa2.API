using Microsoft.AspNetCore.Mvc;
using MLT.Rifa2.API.DTOs;
using MLT.Rifa2.API.Interfaces;

namespace MLT.Rifa2.API.Controllers
{
    public class OrganizationFormController : ControllerBase
    {
        private readonly IOrganizationFormService _organizationFormService;

        public OrganizationFormController(IOrganizationFormService organizationFormService)
        {
            _organizationFormService = organizationFormService;
        }
    }
}
