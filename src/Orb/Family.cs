using System;
using System.Collections.Generic;
using System.Text;

namespace Orb
{
    public class Family : Organization
    {
        public const byte LEVEL = (byte)MemberTypes.Family;

        public string Description { get; set; }

        public override byte Level => LEVEL;

        protected override string Type { get; set; } = nameof(Family);
    }
}
