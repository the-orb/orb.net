using GraphQL.Entity;
using GraphQL.Types;

namespace Orb
{
    class OrganizationQuery : EntityGraphType
    {
        public OrganizationQuery(IEntityGraphAdapter adapter)
            : base(adapter)
        {
        }
    }
}
