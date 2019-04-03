using System.Data.Entity.ModelConfiguration;

namespace Orb
{
    class BrandEntityTypeConfiguration : EntityTypeConfiguration<BrandEntity>
    {
        public BrandEntityTypeConfiguration()
        {
            ToTable("Brands");

            HasKey(x => x.UId);
        }
    }
}
