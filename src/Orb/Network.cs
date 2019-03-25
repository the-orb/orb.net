using System;
using System.Collections.Generic;
using System.Text;

namespace Orb
{
    public class Network : Organization
    {
        public const byte LEVEL = (byte)OrganizationTypes.Network;

        public string Description { get; set; }

        public override byte Level => LEVEL;

        public string Name { get; set; }
    }
}
