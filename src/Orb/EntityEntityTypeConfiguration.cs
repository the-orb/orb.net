using System.Data.Entity.ModelConfiguration;

namespace Orb
{
    class EntityEntityTypeConfiguration : EntityTypeConfiguration<Entity>
    {
        public EntityEntityTypeConfiguration()
        {
            ToTable("Entities");

            HasKey(x => x.Id);

            Property(x => x.Name);

            Property(x => x.Since);

            Property(x => x.Until);

            Ignore(x => x.Level);
        }
    }
}
