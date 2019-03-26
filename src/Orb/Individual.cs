using System;
using System.Collections.Generic;
using System.Text;

namespace Orb
{
    public class Individual : Member
    {
        public const byte LEVEL = (byte)MemberTypes.Individual;

        public string Forename { get; set; }

        public override byte Level => LEVEL;

        public string Surname { get; set; }

        protected override string Type { get; set; } = nameof(Individual);
    }
}
