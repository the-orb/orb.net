using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Spec
{
    internal class RegionEntityTypeConfiguration : EntityTypeConfiguration<RegionEntity>
    {
        public RegionEntityTypeConfiguration()
        {
            ToTable("regions");

            HasKey(x => x.RegionId);

            Property(x => x.RegionId)
                .HasColumnName("region_id")
                .HasColumnOrder(1)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("region_name")
                .HasColumnOrder(2)
                .HasMaxLength(RegionEntity.MAX_LENGTH)
                .IsRequired();

            Property(x => x.PhoneCode)
                .HasColumnName("phone_code")
                .HasColumnOrder(3)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsOptional();

            Property(x => x.IsCountry)
                .HasColumnName("is_country")
                .HasColumnOrder(4)
                .IsRequired();
        }
    }
}
