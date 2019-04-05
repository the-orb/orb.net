using GraphQL.Types;

namespace Orb
{
    internal class OrbMutation : CompositeObjectGraphType
    {
        public OrbMutation()
        {
            Extend(new BrandMutation());
            Extend(new FamilyMutation());
            Extend(new IndividualMutation());
            Extend(new MarketMutation());
            Extend(new MemberMutation());
            Extend(new OrganizationMutation());
            Extend(new DivisionMutation());
        }
    }
}
