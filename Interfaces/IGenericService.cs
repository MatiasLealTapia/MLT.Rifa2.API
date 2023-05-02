using MLT.Rifa2.API.DTOs;

namespace MLT.Rifa2.API.Interfaces
{
    public interface IGenericService
    {
        Task<List<GenericItemDTO>> GetOrganizationTypes();
        Task<GenericItemDTO> GetOrganizationType(int idObj);
        Task<List<GenericItemDTO>> GetOrganizationsByType(int idType);
    }
}
