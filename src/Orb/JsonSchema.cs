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

            Company = generator.Generate(typeof(Company));
            Dimension = generator.Generate(typeof(Dimension));
            Family = generator.Generate(typeof(Family));
            Feed = generator.Generate(typeof(Feed));
            Individual = generator.Generate(typeof(Individual));
            Market = generator.Generate(typeof(Market));
            Member = generator.Generate(typeof(Member));
            Membership = generator.Generate(typeof(Membership));
            Network = generator.Generate(typeof(Network));
            Organization = generator.Generate(typeof(Organization));
            Region = generator.Generate(typeof(Region));
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
