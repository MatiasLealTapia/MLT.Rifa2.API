namespace MLT.Rifa2.API.Models
{
    public partial class Referent
    {
        public int ReferentId { get; set; }
        public int ReferentRUT { get; set; }
        public string ReferentDV { get; set; }
        public string ReferentFirstName { get; set; }
        public string ReferentLastName { get; set; }
        public string ReferentCode { get; set; }
        public string ReferentEmail { get; set; }
        public int ReferentPhone { get; set; }
        public DateTime ReferentBirthDay { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
    }
}
