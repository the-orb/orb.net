namespace Orb
{
    internal class OrbQuery : Relay.CompositeObjectGraphType
    {
        public OrbQuery()
        {
            Extend(new FamilyQuery());
            Extend(new IndividualQuery());
            Extend(new MarketQuery());
            Extend(new EntityQuery());
            Extend(new MemberQuery());
            Extend(new OrganizationQuery());
            Extend(new RegionQuery());
        }
    }
}
