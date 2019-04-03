namespace Orb
{
    internal class OrbQuery : Relay.CompositeObjectGraphType
    {
        public OrbQuery()
        {
            Extend(new BrandQuery());
            Extend(new FamilyQuery());
            Extend(new IndividualQuery());
            Extend(new MarketQuery());
            Extend(new MemberQuery());
            Extend(new OrganizationQuery());
            Extend(new DivisionQuery());
        }
    }
}
