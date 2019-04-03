using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Spec
{
    internal class PhoneEntityTypeConfiguration : EntityTypeConfiguration<Phone>
    {
        public PhoneEntityTypeConfiguration()
        {
            ToTable("phones");

            HasKey(x => x.Number);

            Property(x => x.UId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
