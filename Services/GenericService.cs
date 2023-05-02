using Microsoft.EntityFrameworkCore;
using MLT.Rifa2.API.DTOs;
using MLT.Rifa2.API.Interfaces;

namespace MLT.Rifa2.API.Services
{
    public class GenericService : IGenericService
    {
        private readonly Rifa2DbContext context;

        public GenericService(Rifa2DbContext context)
        {
            this.context = context;
        }
        public async Task<List<GenericItemDTO>> GetOrganizationTypes()
        {
            try
            {
                var obj = context.OrganizationType.ToList().Where(x => x.IsDeleted == false);
                if (obj == null)
                    return null;
                List<GenericItemDTO> organizationTypeList = new List<GenericItemDTO>();
                foreach (var item in obj.ToList())
                {
                    organizationTypeList.Add(new GenericItemDTO
                    {
                        Id = item.OrganizationTypeId,
                        Detail = item.OrganizationTypeName
                    });
                }
                return organizationTypeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericItemDTO> GetOrganizationType(int idObj)
        {
            try
            {
                var obj = await context.OrganizationType.FirstOrDefaultAsync(x => x.OrganizationTypeId == idObj && x.IsDeleted == false);
                if (obj == null)
                    return null;
                return new GenericItemDTO
                {
                    Id = obj.OrganizationTypeId,
                    Detail = obj.OrganizationTypeName
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<GenericItemDTO>> GetOrganizationsByType(int idType)
        {
            try
            {
                var obj = context.Organization.ToList().Where(x => x.IsDeleted == false && x.OrganizationTypeId == idType);
                if (obj == null)
                    return null;
                List<GenericItemDTO> organizationList = new List<GenericItemDTO>();
                foreach (var item in obj.ToList())
                {
                    organizationList.Add(new GenericItemDTO
                    {
                        Id = item.OrganizationId,
                        Detail = item.OrganizationName
                    });
                }
                return organizationList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
