using Unity;

namespace Orb
{
    public static class Bootstrapper
    {
        public static void Setup(IUnityContainer container)
        {
            container.RegisterType<OrbMutation>();
            container.RegisterType<OrbQuery>();
            container.RegisterType<OrbSchema>();

            container.RegisterType<Brand>();
            container.RegisterType<InputBrandGraphType>();
            container.RegisterType<BrandMutation>();
            container.RegisterType<BrandQuery>();
            container.RegisterType<BrandGraphType>();

            container.RegisterType<Company>();
            container.RegisterType<InputCompanyGraphType>();
            container.RegisterType<CompanyMutation>();
            container.RegisterType<CompanyQuery>();
            container.RegisterType<CompanyGraphType>();

            container.RegisterType<Family>();
            container.RegisterType<InputFamilyGraphType>();
            container.RegisterType<FamilyMutation>();
            container.RegisterType<FamilyQuery>();
            container.RegisterType<FamilyGraphType>();

            container.RegisterType<Individual>();
            container.RegisterType<IndividualInputType>();
            container.RegisterType<IndividualMutation>();
            container.RegisterType<IndividualQuery>();
            container.RegisterType<IndividualType>();

            container.RegisterType<Market>();
            container.RegisterType<InputMarketGraphType>();
            container.RegisterType<MarketMutation>();
            container.RegisterType<MarketQuery>();
            container.RegisterType<MarketGraphType>();

            container.RegisterType<Member>();
            container.RegisterType<InputMemberGraphType>();
            container.RegisterType<MemberMutation>();
            container.RegisterType<MemberQuery>();
            container.RegisterType<MemberGraphType>();

            container.RegisterType<Network>();
            container.RegisterType<InputNetworkGraphType>();
            container.RegisterType<NetworkMutation>();
            container.RegisterType<NetworkQuery>();
            container.RegisterType<NetworkGraphType>();

            container.RegisterType<Organization>();
            container.RegisterType<InputOrganizationGraphType>();
            container.RegisterType<OrganizationMutation>();
            container.RegisterType<OrganizationQuery>();
            container.RegisterType<OrganizationGraphType>();

            container.RegisterType<Division>();
            container.RegisterType<InputRegionGraphType>();
            container.RegisterType<DivisionMutation>();
            container.RegisterType<DivisionQuery>();
            container.RegisterType<DivisionGraphType>();
        }
    }
}
