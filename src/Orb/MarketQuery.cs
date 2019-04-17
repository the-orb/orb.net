using GraphQL.Entity;
using GraphQL.Types;

namespace Orb
{
    class MarketQuery : EntityGraphType
    {
        public MarketQuery(IEntityGraphAdapter adapter)
            : base(adapter)
        {
        }
    }
}
