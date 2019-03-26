using System.Collections.Generic;

namespace Meta
{
    public abstract class Measure
    {
        public const string IMPERIAL = "imperial";
        public const string METRIC = "metric";
        public const string UNIVERSAL = "universal";

        private static readonly Dictionary<string, Measure> Measures = new Dictionary<string, Measure>
        {
            { Count.NAME, new Count() },
            { Length.NAME, new Length() },
            { Mass.NAME, new Mass() },
            { Money.NAME, new Money() },
            { Temparature.NAME, new Temparature() },
            { Time.NAME, new Time() },
            { Volume.NAME, new Volume() },
            { Weight.NAME, new Weight() },
        };

        public class Count : Measure
        {
            public const string NAME = "count";

            public class Item : Unit<Count>
            {
                public const string NAME = "item";
                public const string SYSTEM = UNIVERSAL;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }
        }

        public class Length : Measure
        {
            public const string NAME = "length";

            public class Centimeter : Unit<Length>
            {
                public const string NAME = "centimeter";
                public const string SYSTEM = METRIC;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }

            public class Foot : Unit<Length>
            {
                public const string NAME = "foot";
                public const string SYSTEM = IMPERIAL;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }

            public class Inch : Unit<Length>
            {
                public const string NAME = "inch";
                public const string SYSTEM = IMPERIAL;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }

            public class Kilometer : Unit<Length>
            {
                public const string NAME = "kilometer";
                public const string SYSTEM = METRIC;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }

            public class Nanometer : Unit<Length>
            {
                public const string NAME = "nanometer";
                public const string SYSTEM = METRIC;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }

            public class Meter : Unit<Length>
            {
                public const string NAME = "meter";
                public const string SYSTEM = METRIC;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }

            public class Millimeter : Unit<Length>
            {
                public const string NAME = "millimeter";
                public const string SYSTEM = METRIC;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }

            public class Yarn : Unit<Length>
            {
                public const string NAME = "yard";
                public const string SYSTEM = IMPERIAL;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }
        }

        public class Mass : Measure
        {
            public const string NAME = "mass";

            public class Carat : Unit<Mass>
            {
                public const string NAME = "carat";
                public const string SYSTEM = IMPERIAL;

                public override string Name => NAME;
                public override string System => SYSTEM;
            }

            public class Stone : Unit<Mass>
            {
                public const string NAME = "stone";
                public const string SYSTEM = IMPERIAL;

                public override string Name => NAME;
                public override string System => SYSTEM;
            }

            public class Tonne : Unit<Mass>
            {
                public const string NAME = "tonne";
                public const string SYSTEM = IMPERIAL;

                public override string Name => NAME;
                public override string System => SYSTEM;
            }
        }

        public class Money : Measure
        {
            public const string NAME = "money";
        }

        public class Temparature : Measure
        {
            public const string NAME = "temperature";

            public class Celsius : Unit<Temparature>
            {
                public const double FACTOR = 273.1;
                public const string NAME = "celsius";

                public override string Name => NAME;
                public override string System => UNIVERSAL;
            }

            public class Fahrenheit : Unit<Temparature>
            {
                public const double FACTOR = 255.4;
                public const string NAME = "fahrenheit";

                public override string Name => NAME;
                public override string System => UNIVERSAL;
            }

            public class Kelvin : Unit<Temparature>
            {
                public const double FACTOR = 1;
                public const string NAME = "kelvin";

                public override string Name => NAME;

                public override string System => UNIVERSAL;
            }
        }

        public class Time : Measure
        {
            public const string NAME = "time";

            public class Day : Unit<Time>
            {
                public const string NAME = "day";

                public override string Name => NAME;

                public override string System => UNIVERSAL;
            }

            public class Hour : Unit<Time>
            {
                public const string NAME = "hour";

                public override string Name => NAME;

                public override string System => UNIVERSAL;
            }

            public class Millisecond : Unit<Time>
            {
                public const string NAME = "millisecond";

                public override string Name => NAME;

                public override string System => UNIVERSAL;
            }

            public class Minute : Unit<Time>
            {
                public const string NAME = "minute";

                public override string Name => NAME;

                public override string System => UNIVERSAL;
            }

            public class Month : Unit<Time>
            {
                public const string NAME = "month";

                public override string Name => NAME;

                public override string System => UNIVERSAL;
            }

            public class Second : Unit<Time>
            {
                public const string NAME = "second";

                public override string Name => NAME;

                public override string System => UNIVERSAL;
            }

            public class Week : Unit<Time>
            {
                public const string NAME = "week";

                public override string Name => NAME;

                public override string System => UNIVERSAL;
            }

            public class Year : Unit<Time>
            {
                public const string NAME = "year";

                public override string Name => NAME;

                public override string System => UNIVERSAL;
            }
        }

        public abstract class Unit
        {
            public abstract string Name { get; }

            public abstract string System { get; }
        }

        public abstract class Unit<T> : Unit where T: Measure
        {
        }

        public class Volume : Measure
        {
            public const string NAME = "volume";
        }

        public class Weight : Measure
        {
            public const string NAME = "weight";

            public class Gram : Unit<Weight>
            {
                public const string NAME = "gram";
                public const string SYSTEM = METRIC;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }

            public class Centigram : Unit<Weight>
            {
                public const string NAME = "centigram";
                public const string SYSTEM = METRIC;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }

            public class Decigram : Unit<Weight>
            {
                public const string NAME = "decigram";
                public const string SYSTEM = METRIC;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }

            public class Dekagram : Unit<Weight>
            {
                public const string NAME = "dekagram";
                public const string SYSTEM = METRIC;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }

            public class Hectogram : Unit<Weight>
            {
                public const string NAME = "hectogram";
                public const string SYSTEM = METRIC;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }

            public class Kilogram : Unit<Weight>
            {
                public const string NAME = "kilogram";
                public const string SYSTEM = METRIC;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }

            public class Milligram : Unit<Weight>
            {
                public const string NAME = "milligram";
                public const string SYSTEM = METRIC;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }

            public class Once : Unit<Weight>
            {
                public const string NAME = "once";
                public const string SYSTEM = IMPERIAL;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }

            public class Pound : Unit<Weight>
            {
                public const string NAME = "pound";
                public const string SYSTEM = IMPERIAL;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }

            public class Ton : Unit<Weight>
            {
                public const string NAME = "ton";
                public const string SYSTEM = IMPERIAL;

                public override string Name => NAME;

                public override string System => SYSTEM;
            }
        }
    }
}
