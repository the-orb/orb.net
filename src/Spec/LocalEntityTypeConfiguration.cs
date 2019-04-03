using System.Data.Entity.ModelConfiguration;

namespace Spec
{
    internal class LocalEntityTypeConfiguration : EntityTypeConfiguration<Local>
    {
        public LocalEntityTypeConfiguration()
        {
            ToTable("locals");

            HasKey(x => x.Md5);

            Property(x => x.Block);

            Property(x => x.Value)
                .HasMaxLength(Local.MAX_LENGTH)
                .IsRequired()
                .IsUnicode(false);
        }
    }
}
