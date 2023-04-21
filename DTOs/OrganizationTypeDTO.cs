using System.ComponentModel.DataAnnotations;

namespace MLT.Rifa2.API.DTOs
{
    public partial class OrganizationTypeDTO
    {
        public int OrganizationTypeId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        public string OrganizationTypeName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
