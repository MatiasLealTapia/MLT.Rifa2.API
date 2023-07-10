using MLT.Rifa2.API.DTOs;

namespace MLT.Rifa2.API.Interfaces
{
    public interface IRaffleService
    {
        Task<bool> CreateRaffle(RaffleDTO raffleDTO);
        Task<IEnumerable<RaffleDTO>> GetListByOrganization(int orgId);
    }
}
