namespace MLT.Rifa2.API.Models
{
    public partial class OrganizationForm
    {
        public int OrganizationFormId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationEmail { get; set; }
        public int OrganizationPhoneNumber { get; set; }
        public string OrganizationFormInformation { get; set; }
        public int OrganizationTypeId { get; set; }
        public OrganizationType OrganizationType { get; set; }
        public bool IsAcepted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
