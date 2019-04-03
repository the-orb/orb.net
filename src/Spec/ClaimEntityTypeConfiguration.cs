using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spec
{
    internal class ClaimEntityTypeConfiguration : EntityTypeConfiguration<ClaimEntity>
    {
        public ClaimEntityTypeConfiguration()
        {
            ToTable("user_claims");

            HasKey(x => new { x.UserId, x.Md5 });

            HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            HasRequired(x => x.ClaimType)
                .WithMany()
                .HasForeignKey(x => x.ClaimTypeId);

            Property(x => x.ClaimTypeId)
                .HasColumnName("type_id")
                .HasColumnOrder(1);

            Property(x => x.Md5)
                .HasColumnName("md5")
                .HasColumnOrder(4)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.UserId)
                .HasColumnName("user_id")
                .HasColumnOrder(3)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Value)
                .HasColumnName("value")
                .HasColumnOrder(2)
                .HasMaxLength(ClaimTypeEntity.MAX_LENGTH)
                .IsRequired()
                .IsUnicode(true);
        }
    }
}
