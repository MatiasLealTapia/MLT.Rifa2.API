namespace MLT.Rifa2.API.Models
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminFirstLastName { get; set; }
        public string AdminSecondLastName { get; set; }
        public string AdminAlias { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public string AdminToken { get; set; }
        public bool Active { get; set; } = true;
    }
}
