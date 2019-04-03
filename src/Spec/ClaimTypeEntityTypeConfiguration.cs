using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spec
{
    internal class ClaimTypeEntityTypeConfiguration : EntityTypeConfiguration<ClaimTypeEntity>
    {
        public ClaimTypeEntityTypeConfiguration()
        {
            ToTable("user_claim_types");

            HasKey(x => x.TypeId);

            Property(x => x.TypeId)
                .HasColumnName("type_id")
                .HasColumnOrder(1)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.TypeName)
                .HasColumnName("type_name")
                .HasColumnOrder(2)
                .HasMaxLength(ClaimTypeEntity.MAX_LENGTH)
                .IsRequired()
                .IsUnicode(false);

            Property(x => x.ValueType)
                .HasColumnName("value_type")
                .HasColumnOrder(3)
                .IsRequired();
        }
    }
}
