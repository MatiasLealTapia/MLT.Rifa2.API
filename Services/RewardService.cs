using MLT.Rifa2.API.DTOs;
using MLT.Rifa2.API.Interfaces;
using MLT.Rifa2.API.Models;

namespace MLT.Rifa2.API.Services
{
    public class RewardService : IRewardService
    {
        private readonly Rifa2DbContext context;
        private readonly IGenericService genericService;

        public RewardService(Rifa2DbContext context, IGenericService genericService)
        {
            this.context = context;
            this.genericService = genericService;
        }

        public async Task<RewardDTO> Add(RewardDTO rewardDTO)
        {
            try
            {
                var objAdd = new Reward
                {
                    RewardId = rewardDTO.RewardId,
                    RewardName = rewardDTO.RewardName,
                    RewardDescription = rewardDTO.RewardDescription,
                    RewardImgUrl = rewardDTO.RewardImgUrl,
                    RaffleId = rewardDTO.RaffleId,
                    IsDeleted = false,
                };
                context.Reward.Add(objAdd);
                await context.SaveChangesAsync();
                return new RewardDTO
                {
                    RewardId = objAdd.RewardId,
                    RewardName = objAdd.RewardName,
                    RewardDescription = objAdd.RewardDescription,
                    RewardImgUrl= objAdd.RewardImgUrl
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RewardDTO> Delete(RewardDTO rewardDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<RewardDTO> Get(int idObj)
        {
            try
            {
                var objAnonymous = from r in context.Reward.ToList()
                                   where r.RewardId == idObj
                                   join raf in context.Raffle.ToList() on r.RaffleId equals raf.RaffleId
                                   select new
                                   {
                                       RewardId= r.RewardId,
                                       RewardName= r.RewardName,
                                       RewardDescription= r.RewardDescription,
                                       RewardImgUrl= r.RewardImgUrl
                                   };
                var obj = objAnonymous.FirstOrDefault(x => x.RewardId == idObj);
                if (obj == null)
                {
                    return null;
                }
                return new RewardDTO
                {
                    RewardId = obj.RewardId,
                    RewardName = obj.RewardName,
                    RewardDescription = obj.RewardDescription,
                    RewardImgUrl = obj.RewardImgUrl
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RewardDTO>> List()
        {
            throw new NotImplementedException();
        }

        public async Task<RewardDTO> Update(RewardDTO rewardDTO)
        {
            throw new NotImplementedException();
        }
    }
}
