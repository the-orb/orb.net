namespace Orb
{
    internal class OrbMutation : Relay.CompositeObjectGraphType
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
