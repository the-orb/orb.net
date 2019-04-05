using GraphQL.Entity;
using GraphQL.Types;

namespace Orb
{
    class DivisionQuery : EntityGraphType
    {
        public DivisionQuery(IEntityGraphAdapter adapter)
            : base(adapter)
        {
        }
    }
}
