namespace MLT.Rifa2.API.Models
{
    public class OrgAdmin
    {
        public int OrgAdminId { get; set; }
        public string OrgAdminEmail { get; set; }
        public string OrgAdminPasswordHash { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
