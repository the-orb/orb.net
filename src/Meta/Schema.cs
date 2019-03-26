using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meta
{
    public class Schema
    {
        public const string INTEGER = @"integer";
        public const string NUMBER = @"number";
        public const string STRING = @"string";

        static Dictionary<string, JSchema> _schema = new Dictionary<string, JSchema>
        {
            {
                INTEGER,
                new JSchema
                {
                    Type = JSchemaType.Integer
                }
            },
            {
                NUMBER,
                new JSchema
                {
                    Type = JSchemaType.Number
                }
            },
            {
                STRING,
                new JSchema
                {
                    Type = JSchemaType.String
                }
            }
        };

        public static JSchema Range(double min, double max) => new JSchema
        {
            Type = JSchemaType.Number,
            Maximum = max,
            Minimum = min
        };

        public static JSchema Range(int min, int max) => new JSchema
        {
            Type = JSchemaType.Integer,
            Maximum = max,
            Minimum = min
        };

        public static JSchema Enum(params string[] values) => JSchema.Parse($"{{ \"type\": \"{STRING}\", \"enum\": [{String.Join(", ", values.Select(v => $"\"{v}\""))}] }}");

        public static void Validate()
        {
            
        }
    }
}
