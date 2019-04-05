using GraphQL.Entity;
using GraphQL.Types;

namespace Orb
{
    class FamilyQuery : EntityGraphType
    {
        public FamilyQuery(IEntityGraphAdapter adapter)
            : base(adapter)
        {
        }
    }
}
