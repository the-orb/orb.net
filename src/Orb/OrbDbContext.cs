using System.Data.Entity;
using System.Threading.Tasks;

namespace Orb
{
    public class OrbDbContext : DbContext,
        Spec.IDomainDbContext,
        Spec.IEmailDbContext,
        Spec.ILocalDbContext,
        Spec.INameDbContext,
        Spec.IPhoneDbContext
    {
        public DbSet<Spec.Domain> Domains => throw new System.NotImplementedException();

        public DbSet<Spec.Email> Emails => throw new System.NotImplementedException();

        public DbSet<Spec.Domain> Locals => throw new System.NotImplementedException();

        public DbSet<Spec.Name> Names => throw new System.NotImplementedException();

        public DbSet<Spec.Phone> Phones => throw new System.NotImplementedException();
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new Spec.DomainEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Spec.EmailEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Spec.LocalEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Spec.NameEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new CompanyEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new DimensionEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FamilyEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FeedEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new IndividualEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new MarketEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new EntityEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new MemberEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new OrganizationEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new DivisionEntityTypeConfiguration());
        }
    }
}
