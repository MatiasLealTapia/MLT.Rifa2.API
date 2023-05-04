using MLT.Rifa2.API.DTOs;

namespace MLT.Rifa2.API.Interfaces
{
    public interface IReferentService
    {
        Task<ReferentDTO> Get(int idObj);
        Task<ReferentDTO> Add(ReferentDTO referentDTO);
        Task<ReferentDTO> Update(ReferentDTO referentDTO);
        Task<ReferentDTO> Delete(ReferentDTO referentDTO);
        Task<List<ReferentDTO>> List();
        Task<ReferentDTO> GetByRut(int referentRut);
    }
}
