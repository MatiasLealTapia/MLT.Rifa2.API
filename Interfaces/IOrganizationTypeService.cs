using MLT.Rifa2.API.DTOs;

namespace MLT.Rifa2.API.Interfaces
{
    public interface IOrganizationTypeService
    {
        Task<OrganizationTypeDTO> Get(int idObj);
        Task<OrganizationTypeDTO> Add(OrganizationTypeDTO organizationTypeDTO);
        Task<OrganizationTypeDTO> Update(OrganizationTypeDTO organizationTypeDTO);
        Task<OrganizationTypeDTO> Delete(OrganizationTypeDTO organizationTypeDTO);
        Task<List<OrganizationTypeDTO>> List();
    }
}
