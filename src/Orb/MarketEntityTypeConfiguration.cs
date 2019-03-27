using System.Data.Entity.ModelConfiguration;

namespace Orb
{
    class MarketEntityTypeConfiguration : EntityTypeConfiguration<MarketEntity>
    {
        public MarketEntityTypeConfiguration()
        {
            ToTable("Markets");

            // Table Per Concrete Type
            // which will contain columns for all of the class’ properties, including inherited ones.
            // Omit for Table Per Type 
            // with base class into a table of its own and each derived class in its own table, connected to the base table by a foreign key. 
            // Map(x => x.MapInheritedProperties());
        }
    }
}
