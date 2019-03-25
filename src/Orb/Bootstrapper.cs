﻿namespace Orb
{
    public static class Bootstrapper
    {
        public static void Setup(IoC.ISimpleContainer container)
        {
            container.Register<IOrbData>();

            container.Register<OrbMutation>();
            container.Register<OrbQuery>();
            container.Register<OrbSchema>();

            container.Register<Family>();
            container.Register<FamilyInputType>();
            container.Register<FamilyMutation>();
            container.Register<FamilyQuery>();
            container.Register<FamilyType>();

            container.Register<Individual>();
            container.Register<IndividualInputType>();
            container.Register<IndividualMutation>();
            container.Register<IndividualQuery>();
            container.Register<IndividualType>();

            container.Register<Market>();
            container.Register<MarketInputType>();
            container.Register<MarketMutation>();
            container.Register<MarketQuery>();
            container.Register<MarketType>();

            container.Register<Member>();
            container.Register<MemberInputType>();
            container.Register<MemberMutation>();
            container.Register<MemberQuery>();
            container.Register<MemberType>();

            container.Register<Membership>();
            container.Register<MembershipInputType>();
            container.Register<MembershipMutation>();
            container.Register<MembershipQuery>();
            container.Register<MembershipType>();

            container.Register<Network>();
            container.Register<NetworkInputType>();
            container.Register<NetworkMutation>();
            container.Register<NetworkQuery>();
            container.Register<NetworkType>();

            container.Register<Organization>();
            container.Register<OrganizationInputType>();
            container.Register<OrganizationMutation>();
            container.Register<OrganizationQuery>();
            container.Register<OrganizationType>();

            container.Register<Region>();
            container.Register<RegionInputType>();
            container.Register<RegionMutation>();
            container.Register<RegionQuery>();
            container.Register<RegionType>();
        }
    }
}
