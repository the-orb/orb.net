using System;
using System.Collections.Generic;
using System.Text;

namespace Orb
{
    public class Network : Organization
    {
        public const byte LEVEL = (byte)MemberTypes.Network;

        public string Description { get; set; }

        public override byte Level => LEVEL;

        public virtual Market Market { get; set; }

        public Guid MarketId { get; set; }

        protected override string Type { get; set; } = nameof(Network);
    }
}
