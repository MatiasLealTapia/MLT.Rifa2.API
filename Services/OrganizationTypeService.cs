using Microsoft.EntityFrameworkCore;
using MLT.Rifa2.API.DTOs;
using MLT.Rifa2.API.Interfaces;
using MLT.Rifa2.API.Models;

namespace MLT.Rifa2.API.Services
{
    public class OrganizationTypeService : IOrganizationTypeService
    {
        private readonly Rifa2DbContext context;

        public OrganizationTypeService(Rifa2DbContext context)
        {
            this.context = context;
        }
        public async Task<OrganizationTypeDTO> Add(OrganizationTypeDTO organizationTypeDTO)
        {
            try
            {
                var objAdd = new OrganizationType
                {
                    OrganizationTypeId = organizationTypeDTO.OrganizationTypeId,
                    OrganizationTypeName = organizationTypeDTO.OrganizationTypeName,
                    IsDeleted = false,
                };
                context.OrganizationType.Add(objAdd);
                await context.SaveChangesAsync();
                return new OrganizationTypeDTO
                {
                    OrganizationTypeId = objAdd.OrganizationTypeId,
                    OrganizationTypeName = objAdd.OrganizationTypeName,
                    IsDeleted = false,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<OrganizationTypeDTO> Delete(OrganizationTypeDTO organizationTypeDTO)
        {
            var objDelete = await context.OrganizationType.FirstOrDefaultAsync(x => x.OrganizationTypeId == organizationTypeDTO.OrganizationTypeId && x.IsDeleted == false);
            if (objDelete != null)
            {
                objDelete.IsDeleted = true;
            }
            await context.SaveChangesAsync();
            return new OrganizationTypeDTO
            {
                OrganizationTypeId = objDelete.OrganizationTypeId,
                OrganizationTypeName = objDelete.OrganizationTypeName,
                IsDeleted = objDelete.IsDeleted,
            };
        }

        public async Task<OrganizationTypeDTO> Get(int idObj)
        {
            try
            {
                var obj = await context.OrganizationType.FirstOrDefaultAsync(x => x.OrganizationTypeId == idObj);
                if (obj == null)
                    return null;
                return new OrganizationTypeDTO
                {
                    OrganizationTypeId = obj.OrganizationTypeId,
                    OrganizationTypeName = obj.OrganizationTypeName,
                    IsDeleted = obj.IsDeleted,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OrganizationTypeDTO>> List()
        {
            try
            {
                var obj = context.OrganizationType.ToList();
                if (obj == null)
                    return null;
                List<OrganizationTypeDTO> organizationTypeList = new List<OrganizationTypeDTO>();
                foreach (var item in obj.ToList())
                {
                    organizationTypeList.Add(new OrganizationTypeDTO
                    {
                        OrganizationTypeId = item.OrganizationTypeId,
                        OrganizationTypeName = item.OrganizationTypeName,
                        IsDeleted = item.IsDeleted,
                    });
                }
                return organizationTypeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrganizationTypeDTO> Update(OrganizationTypeDTO organizationTypeDTO)
        {
            var objUpdate = await context.OrganizationType.FirstOrDefaultAsync(x => x.OrganizationTypeId == organizationTypeDTO.OrganizationTypeId && x.IsDeleted == false);
            if (objUpdate != null)
            {
                objUpdate.OrganizationTypeName = organizationTypeDTO.OrganizationTypeName;
            }
            await context.SaveChangesAsync();
            return new OrganizationTypeDTO
            {
                OrganizationTypeId = objUpdate.OrganizationTypeId,
                OrganizationTypeName = objUpdate.OrganizationTypeName,
                IsDeleted = false,
            };
        }
    }
}
