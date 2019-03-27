using System.Data.Entity.ModelConfiguration;

namespace Spec
{
    internal class NameEntityTypeConfiguration : EntityTypeConfiguration<Name>
    {
        public NameEntityTypeConfiguration()
        {
            ToTable("Names");

            HasKey(x => x.Md5);

            Property(x => x.Value).HasMaxLength(Name.MAX_LENGTH).IsRequired().IsUnicode(false);
        }
    }
}
