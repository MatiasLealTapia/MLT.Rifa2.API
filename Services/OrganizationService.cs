using Microsoft.EntityFrameworkCore;
using MLT.Rifa2.API.DTOs;
using MLT.Rifa2.API.Interfaces;
using MLT.Rifa2.API.Models;

namespace MLT.Rifa2.API.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly Rifa2DbContext context;
        private readonly IGenericService _genericService;

        public OrganizationService(Rifa2DbContext context, IGenericService genericService)
        {
            this.context = context;
            _genericService = genericService;
        }
        public async Task<OrganizationDTO> Add(OrganizationDTO organizationDTO)
        {
            try
            {
                var orgType = await _genericService.GetOrganizationType(organizationDTO.OrganizationTypeId);
                if (orgType == null)
                {
                    throw new Exception("OrganizationTypeId NO encontrado.");
                }
                var objAdd = new Organization
                {
                    OrganizationId = organizationDTO.OrganizationId,
                    OrganizationName = organizationDTO.OrganizationName,
                    OrganizationTypeId = organizationDTO.OrganizationTypeId,
                    CreationDate = DateTime.Now,
                    IsActive = false,
                    IsDeleted = false,
                };
                context.Organization.Add(objAdd);
                await context.SaveChangesAsync();
                return new OrganizationDTO
                {
                    OrganizationId = objAdd.OrganizationId,
                    OrganizationName = objAdd.OrganizationName,
                    OrganizationTypeId = objAdd.OrganizationTypeId,
                    OrganizationTypeName = orgType.Detail,
                    CreationDate = objAdd.CreationDate,
                    IsActive = objAdd.IsActive,
                    IsDeleted = objAdd.IsDeleted,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrganizationDTO> Delete(OrganizationDTO organizationDTO)
        {
            var objDelete = await context.Organization.FirstOrDefaultAsync(x => x.OrganizationId == organizationDTO.OrganizationId && x.IsDeleted == false);
            if (objDelete != null)
            {
                objDelete.IsDeleted = true;
            }
            await context.SaveChangesAsync();
            return new OrganizationDTO
            {
                OrganizationId = objDelete.OrganizationId,
                OrganizationName = objDelete.OrganizationName,
                IsDeleted = objDelete.IsDeleted,
            };
        }

        public async Task<OrganizationDTO> Get(int idObj)
        {
            try
            {
                var objAnonymous = from o in context.Organization.ToList()
                                   where o.OrganizationId == idObj
                                   join ot in context.OrganizationType.ToList() on o.OrganizationTypeId equals ot.OrganizationTypeId
                                   select new
                                   {
                                       OrganizationId = o.OrganizationId,
                                       OrganizationName = o.OrganizationName,
                                       OrganizationTypeId = o.OrganizationTypeId,
                                       OrganizationTypeName = ot.OrganizationTypeName,
                                       CreationDate = o.CreationDate,
                                       IsActive = o.IsActive,
                                       IsDeleted = o.IsDeleted,
                                   };
                var obj = objAnonymous.FirstOrDefault(x => x.OrganizationId == idObj);
                if (obj == null)
                    return null;
                return new OrganizationDTO
                {
                    OrganizationId = obj.OrganizationId,
                    OrganizationName = obj.OrganizationName,
                    OrganizationTypeId = obj.OrganizationTypeId,
                    OrganizationTypeName = obj.OrganizationTypeName,
                    CreationDate = obj.CreationDate,
                    IsActive = obj.IsActive,
                    IsDeleted = obj.IsDeleted,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OrganizationDTO>> List()
        {
            try
            {
                var obj = from o in context.Organization.ToList()
                          join ot in context.OrganizationType.ToList() on o.OrganizationTypeId equals ot.OrganizationTypeId
                          select new
                          {
                              OrganizationId = o.OrganizationId,
                              OrganizationName = o.OrganizationName,
                              OrganizationTypeId = o.OrganizationTypeId,
                              OrganizationTypeName = ot.OrganizationTypeName,
                              CreationDate = o.CreationDate,
                              IsActive = o.IsActive,
                              IsDeleted = o.IsDeleted,
                          };
                if (obj == null)
                    return null;
                List<OrganizationDTO> organizationList = new List<OrganizationDTO>();
                foreach (var item in obj.ToList())
                {
                    organizationList.Add(new OrganizationDTO
                    {
                        OrganizationId = item.OrganizationId,
                        OrganizationName = item.OrganizationName,
                        OrganizationTypeId = item.OrganizationTypeId,
                        OrganizationTypeName = item.OrganizationTypeName,
                        CreationDate = item.CreationDate,
                        IsActive = item.IsActive,
                        IsDeleted = item.IsDeleted,
                    });
                }
                return organizationList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrganizationDTO> Update(OrganizationDTO organizationDTO)
        {
            try
            {
                var objUpdate = await context.Organization.FirstOrDefaultAsync(x => x.OrganizationId == organizationDTO.OrganizationId && x.IsDeleted == false);
                if (objUpdate != null)
                {
                    objUpdate.OrganizationName = organizationDTO.OrganizationName;
                    objUpdate.OrganizationTypeId = organizationDTO.OrganizationTypeId;
                    objUpdate.IsActive = organizationDTO.IsActive;
                }
                var orgType = await _genericService.GetOrganizationType(objUpdate.OrganizationTypeId);
                if (orgType == null)
                {
                    throw new Exception("OrganizationTypeId NO encontrado.");
                }
                await context.SaveChangesAsync();
                return new OrganizationDTO
                {
                    OrganizationId = objUpdate.OrganizationId,
                    OrganizationName = objUpdate.OrganizationName,
                    OrganizationTypeId = objUpdate.OrganizationTypeId,
                    OrganizationTypeName = orgType.Detail,
                    CreationDate = objUpdate.CreationDate,
                    IsActive = objUpdate.IsActive,
                    IsDeleted = objUpdate.IsDeleted,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
