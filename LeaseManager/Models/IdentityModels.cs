using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeaseManager.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<VehicleAllocation> VehicleAllocations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure relationships and constraints
            modelBuilder.Entity<Lease>()
                .HasRequired(l => l.Vehicle)
                .WithMany(v => v.Leases)
                .HasForeignKey(l => l.VehicleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lease>()
                .HasRequired(l => l.Client)
                .WithMany(c => c.Leases)
                .HasForeignKey(l => l.ClientId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lease>()
                .HasOptional(l => l.Driver)
                .WithMany(d => d.Leases)
                .HasForeignKey(l => l.DriverId);

            base.OnModelCreating(modelBuilder);
        }
    }
}