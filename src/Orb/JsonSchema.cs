using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Serialization;

namespace Orb
{
    public static class JsonSchema
    {
        static JsonSchema()
        {
            var generator = new JSchemaGenerator
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            Company = generator.Generate(typeof(CompanyEntity));
            Dimension = generator.Generate(typeof(Dimension));
            Family = generator.Generate(typeof(FamilyEntity));
            Feed = generator.Generate(typeof(FeedEntity));
            Individual = generator.Generate(typeof(IndividualEntity));
            Market = generator.Generate(typeof(MarketEntity));
            Member = generator.Generate(typeof(Entity));
            Membership = generator.Generate(typeof(MemberEntity));
            Network = generator.Generate(typeof(NetworkEntity));
            Organization = generator.Generate(typeof(OrganizationEntity));
            Region = generator.Generate(typeof(DivisionEntity));
        }

        public static JSchema Company { get; }

        public static JSchema Dimension { get; }

        public static JSchema Family { get; }

        public static JSchema Feed { get; }

        public static JSchema Individual { get; }

        public static JSchema Market { get; }

        public static JSchema Member { get; }

        public static JSchema Membership { get; }

        public static JSchema Network { get; }

        public static JSchema Organization { get; }

        public static JSchema Region { get; }

    }
}
