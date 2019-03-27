using System.Data.Entity.ModelConfiguration;

namespace Spec
{
    internal class LocalEntityTypeConfiguration : EntityTypeConfiguration<Local>
    {
        public LocalEntityTypeConfiguration()
        {
            ToTable("Locals");

            HasKey(x => x.Md5);

            Property(x => x.UId);

            Property(x => x.Value).HasMaxLength(Local.MAX_LENGTH).IsRequired().IsUnicode(false);
        }
    }
}
