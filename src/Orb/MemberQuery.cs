using GraphQL.Entity;
using GraphQL.Types;

namespace Orb
{
    class MemberQuery : EntityGraphType
    {
        public MemberQuery(IEntityGraphAdapter adapter)
            : base(adapter)
        {
        }
    }
}
