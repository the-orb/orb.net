namespace Orb
{
    internal class OrbMutation : Relay.CompositeObjectGraphType
    {
        public OrbMutation()
        {
            Extend(new FamilyMutation());
            Extend(new IndividualMutation());
            Extend(new MarketMutation());
            Extend(new MemberMutation());
            Extend(new MembershipMutation());
            Extend(new OrganizationMutation());
            Extend(new RegionMutation());
        }
    }
}
