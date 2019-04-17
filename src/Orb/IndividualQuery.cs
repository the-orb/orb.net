using GraphQL.Entity;
using GraphQL.Types;

namespace Orb
{
    class IndividualQuery : EntityGraphType
    {
        public IndividualQuery(IEntityGraphAdapter adapter)
            : base(adapter)
        {
        }
    }
}
