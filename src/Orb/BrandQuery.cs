using GraphQL.Entity;

namespace Orb
{
    class BrandQuery : EntityGraphType
    {
        public BrandQuery(IEntityGraphAdapter adapter)
            : base(adapter)
        {
        }
    }
}
