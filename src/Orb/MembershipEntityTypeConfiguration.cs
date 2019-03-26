using System.Data.Entity.ModelConfiguration;

namespace Orb
{
    class MembershipEntityTypeConfiguration : EntityTypeConfiguration<Membership>
    {
        public MembershipEntityTypeConfiguration()
        {
            ToTable("Memberships");

            HasKey(x => new { x.Member, x.Organization });

            Property(x => x.MembershipType);

            Property(x => x.Since);

            Property(x => x.Until);
        }
    }
}
