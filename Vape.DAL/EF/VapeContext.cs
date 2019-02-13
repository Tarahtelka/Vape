using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Vape.DAL.Entities;
using VapeApp.DAL.Entities;

namespace VapeApp.DAL.EF
{
    public class VapeContext :  IdentityDbContext<ApplicationUser>
    {
        public DbSet<FullVape> FullVapes { get; set; }
        public DbSet<Drip> Drips { get; set; }
        public DbSet<BoxMod> BoxMods { get; set; }
        public DbSet<Fluid> Fluids { get; set; }
        public DbSet<MechMod> MechMods { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<ImageFluid> ImageFluids { get; set; }
        public DbSet<ImageDrip> ImageDrips { get; set; }
        public DbSet<ImageMechMod> ImageMechMods { get; set; }
        public DbSet<ImageTank> ImageTanks { get; set; }
        public DbSet<ImageBoxMod> ImageBoxMods { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<ClientProfile> ClientProfiles { get; set; }

        static VapeContext()
        {
            Database.SetInitializer<VapeContext>(new StoreDbInitializer());
        }

        public VapeContext(string connectionString)
                : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<VapeContext>
    {
        protected override void Seed(VapeContext db)
        
            db.SaveChanges();
        }
    }
}