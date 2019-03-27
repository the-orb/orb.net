using System.Data.Entity.ModelConfiguration;

namespace Orb
{
    class MemberEntityTypeConfiguration : EntityTypeConfiguration<Member>
    {
        public MemberEntityTypeConfiguration()
        {
            ToTable("Members");

            HasKey(x => x.Id);

            Property(x => x.Name);

            Property(x => x.Since);

            Property(x => x.Until);

            Ignore(x => x.Level);
        }
    }
}
