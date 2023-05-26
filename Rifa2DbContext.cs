using Microsoft.EntityFrameworkCore;
using MLT.Rifa2.API.Models;

namespace MLT.Rifa2.API
{
    public class Rifa2DbContext : DbContext
    {
        public Rifa2DbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationType> OrganizationType { get; set; }
        public virtual DbSet<OrgAdmin> OrgAdmin { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Referent> Referent { get; set; }
        public virtual DbSet<Raffle> Raffle { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Number> Number { get; set; }
        public virtual DbSet<NumberPurchased> NumberPurchased { get; set; }
        public virtual DbSet<Reward> Reward { get; set; }
        public virtual DbSet<Winner> Winner { get; set; }
    }
}
