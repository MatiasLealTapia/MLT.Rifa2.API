using MLT.Rifa2.API.DTOs;
using MLT.Rifa2.API.Interfaces;
using MLT.Rifa2.API.Models;
using MLT.Rifa2.API.Generic;
using Microsoft.EntityFrameworkCore;

namespace MLT.Rifa2.API.Services
{
    public class ReferentService : IReferentService
    {
        private readonly Rifa2DbContext context;
        private readonly IGenericService _genericService;

        public ReferentService(Rifa2DbContext context, IGenericService genericService)
        {
            this.context = context;
            _genericService = genericService;
        }
        public async Task<ReferentDTO> Add(ReferentDTO referentDTO)
        {
            try
            {
                if (_genericService.GetReferents().Result.Any())
                {
                    if (await context.Referent.FirstOrDefaultAsync(x => x.ReferentRUT == referentDTO.ReferentRUT && x.IsDeleted == false) != null)
                    {
                        throw new Exception("El RUT ya está en uso, NO puedes agregar.");
                    }
                    if (await context.Referent.FirstOrDefaultAsync(x => x.ReferentEmail == referentDTO.ReferentEmail && x.IsDeleted == false) != null)
                    {
                        throw new Exception("El EMAIL ya está en uso, NO puedes agregar.");
                    }
                }
                var org = await _genericService.GetOrganization(referentDTO.OrganizationId);
                if (org == null)
                {
                    throw new Exception("OrganizationId NO encontrado.");
                }
                var objAdd = new Referent
                {
                    ReferentId = referentDTO.ReferentId,
                    ReferentRUT = referentDTO.ReferentRUT,
                    ReferentDV = Tools.CalculateDV(referentDTO.ReferentRUT),
                    ReferentFirstName = referentDTO.ReferentFirstName,
                    ReferentLastName = referentDTO.ReferentLastName,
                    ReferentCode = Tools.Reverse(referentDTO.ReferentRUT.ToString()),
                    ReferentEmail = referentDTO.ReferentEmail,
                    ReferentPhone = referentDTO.ReferentPhone,
                    ReferentBirthDay = referentDTO.ReferentBirthDay,
                    OrganizationId = referentDTO.OrganizationId,
                    CreationDate = DateTime.Now,
                    IsActive = false,
                    IsDeleted = false,
                };
                context.Referent.Add(objAdd);
                await context.SaveChangesAsync();
                return new ReferentDTO
                {
                    ReferentId = objAdd.ReferentId,
                    ReferentRUT = objAdd.ReferentRUT,
                    ReferentDV = objAdd.ReferentDV,
                    ReferentFirstName = objAdd.ReferentFirstName,
                    ReferentLastName = objAdd.ReferentLastName,
                    ReferentCode = objAdd.ReferentCode,
                    ReferentEmail = objAdd.ReferentEmail,
                    ReferentPhone = objAdd.ReferentPhone,
                    ReferentBirthDay = objAdd.ReferentBirthDay,
                    OrganizationId = objAdd.OrganizationId,
                    OrganizationName = org.Detail,
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

        public async Task<ReferentDTO> Delete(ReferentDTO referentDTO)
        {
            try
            {
                var objDelete = await context.Referent.FirstOrDefaultAsync(x => x.ReferentId == referentDTO.ReferentId && x.IsDeleted == false);
                if (objDelete != null)
                {
                    objDelete.IsActive = false;
                    objDelete.IsDeleted = true;
                }
                await context.SaveChangesAsync();
                var org = await _genericService.GetOrganization(objDelete.OrganizationId);
                return new ReferentDTO
                {
                    ReferentId = objDelete.ReferentId,
                    ReferentRUT = objDelete.ReferentRUT,
                    ReferentDV = objDelete.ReferentDV,
                    ReferentFirstName = objDelete.ReferentFirstName,
                    ReferentLastName = objDelete.ReferentLastName,
                    ReferentCode = objDelete.ReferentCode,
                    ReferentEmail = objDelete.ReferentEmail,
                    ReferentPhone = objDelete.ReferentPhone,
                    ReferentBirthDay = objDelete.ReferentBirthDay,
                    OrganizationId = objDelete.OrganizationId,
                    OrganizationName = org.Detail,
                    CreationDate = objDelete.CreationDate,
                    IsActive = objDelete.IsActive,
                    IsDeleted = objDelete.IsDeleted,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ReferentDTO> Get(int idObj)
        {
            try
            {
                var objAnonymous = from r in context.Referent.ToList()
                                   where r.ReferentId == idObj
                                   join o in context.Organization.ToList() on r.OrganizationId equals o.OrganizationId
                                   select new
                                   {
                                       ReferentId = r.ReferentId,
                                       ReferentRUT = r.ReferentRUT,
                                       ReferentDV = r.ReferentDV,
                                       ReferentFirstName = r.ReferentFirstName,
                                       ReferentLastName = r.ReferentLastName,
                                       ReferentCode = r.ReferentCode,
                                       ReferentEmail = r.ReferentEmail,
                                       ReferentPhone = r.ReferentPhone,
                                       ReferentBirthDay = r.ReferentBirthDay,
                                       OrganizationId = r.OrganizationId,
                                       OrganizationName = o.OrganizationName,
                                       CreationDate = r.CreationDate,
                                       IsActive = r.IsActive,
                                       IsDeleted = r.IsDeleted,
                                   };
                var obj = objAnonymous.FirstOrDefault(x => x.ReferentId == idObj);
                if (obj == null)
                {
                    return null;
                }
                return new ReferentDTO
                {
                    ReferentId = obj.ReferentId,
                    ReferentRUT = obj.ReferentRUT,
                    ReferentDV = obj.ReferentDV,
                    ReferentFirstName = obj.ReferentFirstName,
                    ReferentLastName = obj.ReferentLastName,
                    ReferentCode = obj.ReferentCode,
                    ReferentEmail = obj.ReferentEmail,
                    ReferentPhone = obj.ReferentPhone,
                    ReferentBirthDay = obj.ReferentBirthDay,
                    OrganizationId = obj.OrganizationId,
                    OrganizationName = obj.OrganizationName,
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

        public async Task<ReferentDTO> GetByRut(int referentRut)
        {
            try
            {
                var objAnonymous = from r in context.Referent.ToList()
                                   where r.ReferentRUT == referentRut
                                   join o in context.Organization.ToList() on r.OrganizationId equals o.OrganizationId
                                   select new
                                   {
                                       ReferentId = r.ReferentId,
                                       ReferentRUT = r.ReferentRUT,
                                       ReferentDV = r.ReferentDV,
                                       ReferentFirstName = r.ReferentFirstName,
                                       ReferentLastName = r.ReferentLastName,
                                       ReferentCode = r.ReferentCode,
                                       ReferentEmail = r.ReferentEmail,
                                       ReferentPhone = r.ReferentPhone,
                                       ReferentBirthDay = r.ReferentBirthDay,
                                       OrganizationId = r.OrganizationId,
                                       OrganizationName = o.OrganizationName,
                                       CreationDate = r.CreationDate,
                                       IsActive = r.IsActive,
                                       IsDeleted = r.IsDeleted,
                                   };
                var obj = objAnonymous.FirstOrDefault(x => x.ReferentRUT == referentRut);
                if (obj == null)
                {
                    return null;
                }
                return new ReferentDTO
                {
                    ReferentId = obj.ReferentId,
                    ReferentRUT = obj.ReferentRUT,
                    ReferentDV = obj.ReferentDV,
                    ReferentFirstName = obj.ReferentFirstName,
                    ReferentLastName = obj.ReferentLastName,
                    ReferentCode = obj.ReferentCode,
                    ReferentEmail = obj.ReferentEmail,
                    ReferentPhone = obj.ReferentPhone,
                    ReferentBirthDay = obj.ReferentBirthDay,
                    OrganizationId = obj.OrganizationId,
                    OrganizationName = obj.OrganizationName,
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

        public async Task<List<ReferentDTO>> List()
        {
            try
            {
                var obj = from r in context.Referent.ToList()
                          join o in context.Organization.ToList() on r.OrganizationId equals o.OrganizationId
                          select new
                          {
                              ReferentId = r.ReferentId,
                              ReferentRUT = r.ReferentRUT,
                              ReferentDV = r.ReferentDV,
                              ReferentFirstName = r.ReferentFirstName,
                              ReferentLastName = r.ReferentLastName,
                              ReferentCode = r.ReferentCode,
                              ReferentEmail = r.ReferentEmail,
                              ReferentPhone = r.ReferentPhone,
                              ReferentBirthDay = r.ReferentBirthDay,
                              OrganizationId = r.OrganizationId,
                              OrganizationName = o.OrganizationName,
                              CreationDate = r.CreationDate,
                              IsActive = r.IsActive,
                              IsDeleted = r.IsDeleted,
                          };
                if (obj == null)
                {
                    return null;
                }
                List<ReferentDTO> referentList = new List<ReferentDTO>();
                foreach (var item in obj.ToList())
                {
                    referentList.Add(new ReferentDTO
                    {
                        ReferentId = item.ReferentId,
                        ReferentRUT = item.ReferentRUT,
                        ReferentDV = item.ReferentDV,
                        ReferentFirstName = item.ReferentFirstName,
                        ReferentLastName = item.ReferentLastName,
                        ReferentCode = item.ReferentCode,
                        ReferentEmail = item.ReferentEmail,
                        ReferentPhone = item.ReferentPhone,
                        ReferentBirthDay = item.ReferentBirthDay,
                        OrganizationId = item.OrganizationId,
                        OrganizationName = item.OrganizationName,
                        CreationDate = item.CreationDate,
                        IsActive = item.IsActive,
                        IsDeleted = item.IsDeleted,
                    });
                }
                return referentList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ReferentDTO> Update(ReferentDTO referentDTO)
        {
            try
            {
                var objUpdate = await context.Referent.FirstOrDefaultAsync(x => x.ReferentId == referentDTO.ReferentId && x.IsDeleted == false);
                if (await context.Referent.FirstOrDefaultAsync(x => x.ReferentId != referentDTO.ReferentId && x.ReferentEmail == referentDTO.ReferentEmail && x.IsDeleted == false) != null)
                {
                    throw new Exception("El EMAIL ya está en uso, NO puedes agregar.");
                }
                if (objUpdate != null)
                {
                    objUpdate.ReferentFirstName = referentDTO.ReferentFirstName;
                    objUpdate.ReferentLastName = referentDTO.ReferentLastName;
                    objUpdate.ReferentEmail = referentDTO.ReferentEmail;
                    objUpdate.ReferentPhone = referentDTO.ReferentPhone;
                    objUpdate.ReferentBirthDay = referentDTO.ReferentBirthDay;
                    objUpdate.OrganizationId = referentDTO.OrganizationId;
                    objUpdate.IsActive = referentDTO.IsActive;
                }
                var org = await _genericService.GetOrganizationType(objUpdate.OrganizationId);
                if (org == null)
                {
                    throw new Exception("OrganizationId NO encontrado.");
                }
                await context.SaveChangesAsync();
                return new ReferentDTO
                {
                    ReferentId = objUpdate.ReferentId,
                    ReferentRUT = objUpdate.ReferentRUT,
                    ReferentDV = objUpdate.ReferentDV,
                    ReferentFirstName = objUpdate.ReferentFirstName,
                    ReferentLastName = objUpdate.ReferentLastName,
                    ReferentCode = objUpdate.ReferentCode,
                    ReferentEmail = objUpdate.ReferentEmail,
                    ReferentPhone = objUpdate.ReferentPhone,
                    ReferentBirthDay = objUpdate.ReferentBirthDay,
                    OrganizationId = objUpdate.OrganizationId,
                    OrganizationName = org.Detail,
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
