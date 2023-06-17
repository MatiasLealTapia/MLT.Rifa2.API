using MLT.Rifa2.API.DTOs;
using MLT.Rifa2.API.Interfaces;
using MLT.Rifa2.API.Models;

namespace MLT.Rifa2.API.Services
{
    public class OrganizationFormService : IOrganizationFormService
    {
        private readonly Rifa2DbContext context;
        private readonly IGenericService _genericService;

        public OrganizationFormService(Rifa2DbContext context, IGenericService genericService)
        {
            this.context = context;
            _genericService = genericService;
        }
        public async Task<String> Add(OrganizationFormDTO organizationFormDTO)
        {
            try
            {
                var response = "F";
                var orgType = await _genericService.GetOrganizationType(organizationFormDTO.OrganizationTypeId);
                if (orgType == null)
                {
                    throw new Exception("OrganizationTypeId NO encontrado.");
                }
                var objAdd = new OrganizationForm
                {
                    OrganizationFormId = organizationFormDTO.OrganizationFormId,
                    OrganizationName = organizationFormDTO.OrganizationName,
                    OrganizationEmail = organizationFormDTO.OrganizationEmail,
                    OrganizationFormInformation = organizationFormDTO.OrganizationFormInformation,
                    OrganizationPhoneNumber = organizationFormDTO.OrganizationPhoneNumber,
                    OrganizationTypeId = organizationFormDTO.OrganizationTypeId,
                    IsAcepted = organizationFormDTO.IsAcepted,
                    IsDeleted = false,
                };
                context.OrganizationForm.Add(objAdd);
                var isSaved = await context.SaveChangesAsync();
                if (isSaved > 0)
                {
                    response = "T";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrganizationFormDTO> Delete(OrganizationFormDTO organizationFormDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<OrganizationFormDTO> Get(int idObj)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrganizationFormDTO>> List()
        {
            throw new NotImplementedException();
        }

        public async Task<OrganizationFormDTO> Update(OrganizationFormDTO organizationFormDTO)
        {
            throw new NotImplementedException();
        }
    }
}
