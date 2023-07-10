using MLT.Rifa2.API.DTOs;

namespace MLT.Rifa2.API.Interfaces
{
    public interface IOrganizationService
    {
        Task<OrganizationDTO> Get(int idObj);
        Task<OrganizationDTO> Add(OrganizationDTO organizationDTO);
        Task<OrganizationDTO> Update(OrganizationDTO organizationDTO);
        Task<OrganizationDTO> Delete(OrganizationDTO organizationDTO);
        Task<List<OrganizationDTO>> List();
        Task<OrganizationDTO> Login(OrgAdminLogInDTO logInDTO);
    }
}
