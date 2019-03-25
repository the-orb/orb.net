using System;
using System.Collections.Generic;
using System.Text;

namespace Orb
{
    public class Market : Organization
    {
        public const byte LEVEL = (byte)OrganizationTypes.Market;

        public string Description { get; set; }

        public override byte Level => LEVEL;

        public string Name { get; set; }
    }
}
