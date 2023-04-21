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
        public virtual DbSet<Admin> Admin { get; set; }
    }
}
