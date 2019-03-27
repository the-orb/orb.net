namespace Orb
{
    public static class Bootstrapper
    {
        public static void Setup(IoC.ISimpleContainer container)
        {
            container.Register<IOrbData>();

            container.Register<OrbMutation>();
            container.Register<OrbQuery>();
            container.Register<OrbSchema>();

            container.Register<CompanyEntity>();
            container.Register<CompanyInputType>();
            container.Register<CompanyMutation>();
            container.Register<CompanyQuery>();
            container.Register<CompanyType>();

            container.Register<FamilyEntity>();
            container.Register<FamilyInputType>();
            container.Register<FamilyMutation>();
            container.Register<FamilyQuery>();
            container.Register<FamilyType>();

            container.Register<IndividualEntity>();
            container.Register<IndividualInputType>();
            container.Register<IndividualMutation>();
            container.Register<IndividualQuery>();
            container.Register<IndividualType>();

            container.Register<MarketEntity>();
            container.Register<MarketInputType>();
            container.Register<MarketMutation>();
            container.Register<MarketQuery>();
            container.Register<MarketType>();

            container.Register<Entity>();
            container.Register<EntityInputType>();
            container.Register<EntityMutation>();
            container.Register<EntityQuery>();
            container.Register<EntityType>();

            container.Register<MemberEntity>();
            container.Register<MemberInputType>();
            container.Register<MemberMutation>();
            container.Register<MemberQuery>();
            container.Register<MemberType>();

            container.Register<NetworkEntity>();
            container.Register<NetworkInputType>();
            container.Register<NetworkMutation>();
            container.Register<NetworkQuery>();
            container.Register<NetworkType>();

            container.Register<OrganizationEntity>();
            container.Register<OrganizationInputType>();
            container.Register<OrganizationMutation>();
            container.Register<OrganizationQuery>();
            container.Register<OrganizationType>();

            container.Register<RegionEntity>();
            container.Register<RegionInputType>();
            container.Register<RegionMutation>();
            container.Register<RegionQuery>();
            container.Register<RegionType>();
        }
    }
}
