namespace Orb
{
    class MarketEntity : OrganizationEntity
    {
        public const byte LEVEL = (byte)EntityTypes.Market;

        public string Description { get; set; }

        public override byte Level => LEVEL;

        protected override string Type { get; set; } = nameof(MarketEntity);
    }
}
