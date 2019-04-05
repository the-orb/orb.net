using GraphQL.Entity;

namespace Orb
{
    internal class OrbQuery : EntityGraphType
    {
        public OrbQuery(IEntityGraphAdapter adapter)
            : base(adapter)
        {
            Extend(new BrandQuery(adapter));
            Extend(new FamilyQuery(adapter));
            Extend(new IndividualQuery(adapter));
            Extend(new MarketQuery(adapter));
            Extend(new MemberQuery(adapter));
            Extend(new OrganizationQuery(adapter));
            Extend(new DivisionQuery(adapter));
        }
    }
}
