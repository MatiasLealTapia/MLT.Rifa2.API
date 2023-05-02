using MLT.Rifa2.API.Models;
using System.ComponentModel.DataAnnotations;

namespace MLT.Rifa2.API.DTOs
{
    public partial class OrganizationDTO
    {
        public int OrganizationId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        public string OrganizationName { get; set; }
        public int OrganizationTypeId { get; set; }
        public string OrganizationTypeName { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
