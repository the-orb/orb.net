using System.Data.Entity.ModelConfiguration;

namespace Orb
{
    class MemberEntityTypeConfiguration : EntityTypeConfiguration<MemberEntity>
    {
        public MemberEntityTypeConfiguration()
        {
            ToTable("Members");

            HasKey(x => new { x.Entity, x.Organization });

            HasRequired(x => x.Entity).WithMany(x => x.Memberships).HasForeignKey(x => x.EntityId);

            HasRequired(x => x.Organization).WithMany(x => x.Members).HasForeignKey(x => x.OrganizationUId);

            Property(x => x.Role);

            Property(x => x.Since);

            Property(x => x.Until);
        }
    }
}
