using System;

namespace Orb
{
    class NetworkEntity : OrganizationEntity
    {
        public const byte LEVEL = (byte)EntityTypes.Network;

        public string Description { get; set; }

        public override byte Level => LEVEL;

        public virtual MarketEntity Market { get; set; }

        public Guid MarketId { get; set; }

        protected override string Type { get; set; } = nameof(NetworkEntity);
    }
}
