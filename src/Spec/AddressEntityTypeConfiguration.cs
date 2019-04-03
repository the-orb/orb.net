using System.Data.Entity.ModelConfiguration;

namespace Spec
{
    internal class AddressEntityTypeConfiguration : EntityTypeConfiguration<AddressEntity>
    {
        public AddressEntityTypeConfiguration()
        {
            ToTable("addresses");

            HasKey(x => x.AddressId);

            HasRequired(x => x.Region)
                .WithMany()
                .HasForeignKey(x => x.RegionId);
        }
    }
}
