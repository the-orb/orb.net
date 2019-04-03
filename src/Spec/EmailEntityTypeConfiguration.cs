using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Spec
{
    internal class EmailEntityTypeConfiguration : EntityTypeConfiguration<Email>
    {
        public EmailEntityTypeConfiguration()
        {
            ToTable("emails");

            HasRequired(x => x.Domain).WithMany().HasForeignKey(x => x.DomainMd5);

            HasRequired(x => x.Local).WithMany().HasForeignKey(x => x.DomainMd5);

            Property(x => x.DomainMd5).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.LocalMd5).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasKey(x => x.Md5);

            Property(x => x.UId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
