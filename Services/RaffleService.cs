using MLT.Rifa2.API.DTOs;
using MLT.Rifa2.API.Interfaces;
using MLT.Rifa2.API.Models;

namespace MLT.Rifa2.API.Services
{
    public class RaffleService : IRaffleService
    {
        private readonly Rifa2DbContext context;
        private readonly IGenericService _genericService;

        public RaffleService(Rifa2DbContext context, IGenericService genericService)
        {
            this.context = context;
            _genericService = genericService;
        }

        public async Task<bool> CreateRaffle(RaffleDTO raffleDTO)
        {
            try
            {
                var org = await _genericService.GetOrganizationType(raffleDTO.OrganizationId);
                if (org == null)
                {
                    throw new Exception("Organization NO encontrado.");
                }
                var newRaffle = new Raffle
                {
                    RaffleName = raffleDTO.RaffleName,
                    RaffleDescription = raffleDTO.RaffleDescription,
                    RaffleNumberPrice = raffleDTO.RaffleNumberPrice,
                    RaffleNumbersAmount = raffleDTO.RaffleNumbersAmount,
                    RaffleBeginDate = raffleDTO.RaffleBeginDate,
                    RaffleEndDate = raffleDTO.RaffleEndDate,
                    OrganizationId = raffleDTO.OrganizationId,
                    RaffleCreationDate = raffleDTO.RaffleCreationDate,
                    IsActive = false,
                    IsDeleted = false,
                };
                context.Raffle.Add(newRaffle);
                await context.SaveChangesAsync();
                List<Number> numerosRifa = new List<Number>();
                for (int i = 0; i < raffleDTO.RaffleNumbersAmount; i++)
                {
                    Number numero = new Number
                    {
                        NumberPosition = i,
                        RaffleId = newRaffle.RaffleId,
                        IsBuyed = false,
                        IsDeleted = false
                    };
                    numerosRifa.Add(numero);
                };
                context.Number.AddRange(numerosRifa);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<RaffleDTO>> GetListByOrganization(int orgId)
        {
            try
            {
                var orgObj = await _genericService.GetOrganization(orgId);
                var obj = context.Raffle.ToList().Where(x => x.OrganizationId == orgId);
                if (obj == null)
                    return null;
                List<RaffleDTO> raffleList = new List<RaffleDTO>();
                foreach (var item in obj.ToList())
                {
                    raffleList.Add(new RaffleDTO
                    {
                        RaffleId = item.RaffleId,
                        RaffleName = item.RaffleName,
                        RaffleDescription = item.RaffleDescription,
                        RaffleNumberPrice = item.RaffleNumberPrice,
                        RaffleNumbersAmount = item.RaffleNumbersAmount,
                        RaffleBeginDate = item.RaffleBeginDate,
                        RaffleEndDate = item.RaffleEndDate,
                        OrganizationId = item.OrganizationId,
                        OrganizationName = orgObj.Detail,
                        RaffleCreationDate = item.RaffleCreationDate,
                        IsActive = item.IsActive,
                        IsDeleted = item.IsDeleted
                    });
                }
                return raffleList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
