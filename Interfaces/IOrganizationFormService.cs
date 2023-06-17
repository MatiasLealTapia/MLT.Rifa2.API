using MLT.Rifa2.API.DTOs;

namespace MLT.Rifa2.API.Interfaces
{
    public interface IOrganizationFormService
    {
        Task<OrganizationFormDTO> Get(int idObj);
        Task<String> Add(OrganizationFormDTO organizationFormDTO);
        Task<OrganizationFormDTO> Update(OrganizationFormDTO organizationFormDTO);
        Task<OrganizationFormDTO> Delete(OrganizationFormDTO organizationFormDTO);
        Task<List<OrganizationFormDTO>> List();
    }
}
