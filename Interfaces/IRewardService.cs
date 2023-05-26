using MLT.Rifa2.API.DTOs;

namespace MLT.Rifa2.API.Interfaces
{
    public interface IRewardService
    {
        Task<RewardDTO> Get(int idObj);
        Task<RewardDTO> Add(RewardDTO rewardDTO);
        Task<RewardDTO> Update(RewardDTO rewardDTO);
        Task<RewardDTO> Delete(RewardDTO rewardDTO);
        Task<List<RewardDTO>> List();
    }
}
