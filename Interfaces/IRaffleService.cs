using MLT.Rifa2.API.DTOs;

namespace MLT.Rifa2.API.Interfaces
{
    public interface IRaffleService
    {
        Task<bool> CreateRaffle(RaffleDTO raffleDTO);
        Task<bool> NumberBuyed(int numberId);
        Task<IEnumerable<RaffleDTO>> GetList();
        Task<IEnumerable<RaffleDTO>> GetListByOrganization(int orgId);
        Task<RaffleDTO> GetRaffleById(int raffleId);
    }
}
