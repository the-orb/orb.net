using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Spec
{
    internal class DomainEntityTypeConfiguration : EntityTypeConfiguration<Domain>
    {
        public DomainEntityTypeConfiguration()
        {
            ToTable("Domain");

            HasKey(x => x.Md5);

            Property(x => x.UId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Value).HasMaxLength(Domain.MAX_LENGTH).IsRequired().IsUnicode(false);
        }
    }
}
