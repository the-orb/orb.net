using System.Data.Entity;

namespace Orb
{
    class OrbData : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CompanyEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new DimensionEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FamilyEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FeedEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new IndividualEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new MarketEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new MemberEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new MembershipEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new OrganizationEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new RegionEntityTypeConfiguration());
        }
    }
}
